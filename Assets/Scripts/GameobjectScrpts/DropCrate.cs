using UnityEngine;

public class DropCrate : MonoBehaviour, IActivatables
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Activate()
    {
        rb.useGravity = true;
    }
}
