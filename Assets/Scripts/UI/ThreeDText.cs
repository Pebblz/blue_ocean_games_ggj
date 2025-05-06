using TMPro;
using UnityEngine;

public class ThreeDText : MonoBehaviour
{
    [SerializeField] AnimationClip clip;
    public TextMeshPro textMeshPro;
    private Transform cam;
    void Start()
    {
        Destroy(gameObject, clip.length);
        cam = FindFirstObjectByType<Camera>().transform;
        InvokeRepeating("UpdateTowardsCamera", 0,.1f);
    }
    private void UpdateTowardsCamera()
    {
        Vector3 dir = transform.position - cam.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = rot;
    }
}
