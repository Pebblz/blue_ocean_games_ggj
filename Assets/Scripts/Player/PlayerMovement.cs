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
    public bool isDoubleJump;            // Whether the player is double jumping

    private Vector2 moveInput;          // Raw input from the player
    private Vector2 lookInput;          // Raw input from the player mouse
    private Vector3 moveDirection;      // Calculated movement direction relative to camera

    [SerializeField] private GameObject model;              //The Player Model
    [SerializeField] private GameObject playerAimCore;      //The object the camera follows and rotates with
    [SerializeField] private Vector2 wantedVelocity;        //the wanted velocity when moving the mouse or joystick
    [SerializeField] private float sensitivityX;            //holds sensitivity on x axis of either controller or mouse depending on input
    [SerializeField] private float sensitivityY;            //holds sensitivity on y axis of either controller or mouse depending on input
    [SerializeField] private Vector2 velocity = Vector2.zero;//camera velocity
    [SerializeField] private Vector3 newCameraRot;          //new rotation for camera
    [SerializeField] private float viewClampYmin = -30;     //min clamp value for pitch rotation
    [SerializeField] private float viewClampYmax = 30;      //max clamp value for pitch rotation
    //Temp vars DELETE BEFORE COMMITING
    [SerializeField] GameObject TestDummy;
    private Pause pause;
    private PlayerEquipment equipment; 
    void Start()
    {
        isDoubleJump = false;
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        pause = FindFirstObjectByType<Pause>();
        equipment = GetComponent<PlayerEquipment>();
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

    private void LateUpdate()
    {
        //rotate the cameralook at with the cameras new rotation
        playerAimCore.transform.localRotation = Quaternion.Euler(newCameraRot);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded using a raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
        if (isGrounded && isDoubleJump)
        {
            isDoubleJump = false;
        }
        wantedVelocity = lookInput * new Vector2(sensitivityX, sensitivityY);

        velocity = new Vector2(wantedVelocity.x, wantedVelocity.y);

        //camera pitch rotation clamped to a min and max value
        newCameraRot.x += sensitivityY * -velocity.y /*lookVal.y*/ * Time.deltaTime;
        newCameraRot.x = Mathf.Clamp(newCameraRot.x, viewClampYmin, viewClampYmax);

        //camera yaw rotation 
        newCameraRot.y += sensitivityX * velocity.x /*lookVal.x*/ * Time.deltaTime;
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


            // Calculate the target rotation
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            // Smoothly rotate towards the movement direction
            model.transform.rotation = Quaternion.Lerp(model.transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
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
        EquipmentPart legs;
        equipment.equipment.TryGetValue(PART_LOCATION.LEGS, out legs);
        if (context.performed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        } else if( context.performed && !isDoubleJump && legs is DoubleJumpEquipmentPart)
        {
            isGrounded = false;
            isDoubleJump = true;
            legs.Action();
        }
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed && pause != null)
        {
            pause.PauseGame();
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // Read the 2D movement input
        lookInput = context.ReadValue<Vector2>();
    }
    public void TestFunctionDeleteLaterPwease(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TestDummy.GetComponent<EnemyHealth>().GetHit(Random.Range(1, 100));
        }
    }
    #endregion
}
