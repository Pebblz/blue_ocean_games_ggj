using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }
    [HideInInspector] public Pause pause;
    private void Awake() => Instance = this;
    private void Start()
    {
        pause = FindFirstObjectByType<Pause>();
    }
    private GameObject interactibleOBJ;
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && interactibleOBJ != null)
        {
            if (interactibleOBJ.GetComponent<IInteractable>().CanBeInteractedWith())
            {
                interactibleOBJ.GetComponent<IInteractable>().OnInteract();
            }
        }  
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed && pause != null)
        {
            pause.PauseGame();
        }
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.performed && pause != null)
        {
            pause.ToggleInventory();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Interactible")
        {
            interactibleOBJ = col.gameObject;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject == interactibleOBJ)
        {
            interactibleOBJ = null;
        }
    }
}
