using System.Collections.Generic;
using UnityEngine;

public class ConveyerBelt : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    [SerializeField] private List<GameObject> onBeltOBJs;
    [HideInInspector] public bool active = true;
    private void FixedUpdate()
    {
        if (onBeltOBJs.Count > 0 && active)
        {
            for (int i = 0; i <= onBeltOBJs.Count - 1; i++)
            {
                onBeltOBJs[i].GetComponent<Rigidbody>().AddForce(speed * direction);
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            onBeltOBJs.Add(col.transform.parent.gameObject);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            onBeltOBJs.Remove(col.transform.parent.gameObject);
        }
    }
}
