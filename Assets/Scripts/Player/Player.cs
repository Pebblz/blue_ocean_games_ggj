using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
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
