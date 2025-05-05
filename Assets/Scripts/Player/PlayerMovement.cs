using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;        // Speed of player movement
    [SerializeField] private float jumpForce = 5f;        // Force applied when jumping
    [SerializeField] private float groundCheckDistance = 0.2f;  // Distance to check for ground
    [SerializeField] private LayerMask groundLayer;       // Layer mask for ground detection

    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 10f;   // Speed of rotation smoothing
    [SerializeField] private Transform cameraTransform;   // Reference to the main camera


    private Rigidbody rb;                // Reference to the Rigidbody component
    public bool isGrounded;            // Whether the player is touching the ground
    private Vector2 moveInput;          // Raw input from the player
    private Vector3 moveDirection;      // Calculated movement direction relative to camera
    private Pause pause;
    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        pause = FindObjectOfType<Pause>();
        // If no camera transform is assigned, try to find the main camera
        if (cameraTransform == null)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                cameraTransform = mainCamera.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded using a raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    void FixedUpdate()
    {
        // Calculate camera-relative movement direction
        CalculateMovementDirection();

        // Apply movement and rotation
        ApplyMovement();
    }

    /// <summary>
    /// Calculates the movement direction relative to the camera's orientation
    /// </summary>
    private void CalculateMovementDirection()
    {
        if (cameraTransform == null) return;

        // Get the camera's forward and right vectors, but ignore the Y component
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the movement direction relative to camera orientation
        moveDirection = (cameraForward * moveInput.y + cameraRight * moveInput.x).normalized;
    }

    /// <summary>
    /// Applies movement and rotation to the player
    /// </summary>
    private void ApplyMovement()
    {
        if (moveDirection != Vector3.zero)
        {
            // Calculate target velocity
            Vector3 targetVelocity = moveDirection * moveSpeed;
            
            // Preserve the current vertical velocity
            targetVelocity.y = rb.linearVelocity.y;
            
            // Apply the movement
            rb.linearVelocity = targetVelocity;

            // Only rotate if we're not moving backward (when moveInput.y is positive)
            if (moveInput.y >= 0)
            {
                // Calculate the target rotation
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                
                // Smoothly rotate towards the movement direction
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            // Stop horizontal movement when no input
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
        }
    }

    #region Input System callbacks
    public void OnMove(InputAction.CallbackContext context)
    {
        // Read the 2D movement input
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // Only jump if the button was pressed and the player is grounded
        if (context.performed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed && pause != null )
        {
            pause.PauseGame();
        }
    }
    #endregion
}
