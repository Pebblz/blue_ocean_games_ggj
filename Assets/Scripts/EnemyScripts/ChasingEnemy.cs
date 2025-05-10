using UnityEngine;
using UnityEngine.AI;

public class ChasingEnemy : MonoBehaviour, IEnemy
{
    private NavMeshAgent agent;
    private Transform target;
    private void Start()
    {
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

    public void SetPlayer(Transform t)
    {
        target = t;
    }
}
