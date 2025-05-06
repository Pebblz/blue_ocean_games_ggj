using UnityEngine;
using UnityEngine.AI;

public class ChasingEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;
    private void Start()
    {
        //later make the enemy spawn manager set the player transform;
        target = FindFirstObjectByType<PlayerMovement>().transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (agent != null)
        {
            agent.SetDestination(target.position);
        }
    }
    void Attack()
    {

    }
}
