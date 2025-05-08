using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    ParticleSystem system;
    void Start()
    {
        system = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (system.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
