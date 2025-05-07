using UnityEngine;

public class InteractibleButton : MonoBehaviour, IInteractable
{
    [SerializeField] bool isInteractible = true;
    [SerializeField] GameObject activatableOBJ;
    public bool CanBeInteractedWith()
    {
        return isInteractible;
    }
    public void OnInteract()
    {
        activatableOBJ.GetComponent<IActivatables>().Activate();
    }
}
