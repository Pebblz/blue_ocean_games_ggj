using UnityEngine;
using UnityEngine.AI;

public class ChargingEnemy : MonoBehaviour
{
    [Header("Movement Settings")]
    public float chargeSpeed = 10f;
    public float chargeDuration = 2f;
    public float chargeCooldown = 3f;
    public float chargeRadius = 10f;

    private NavMeshAgent navAgent;
    private Transform player;
    private bool isCharging = false;
    private float chargeTimer = 0f;
    private float cooldownTimer = 0f;
    private Vector3 chargeDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();       
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if no player do nothing
        if (player == null) return;
        //gets distance
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (isCharging)
        {
            chargeTimer += Time.deltaTime;
            if (chargeTimer >= chargeDuration)
            {
                StopCharging();
            }
            else
            {
                // Continue charging in the initial direction
                navAgent.Move(chargeDirection * chargeSpeed * Time.deltaTime);
            }
        }
        else
        {
            cooldownTimer += Time.deltaTime;
            
            if (distanceToPlayer <= chargeRadius && cooldownTimer >= chargeCooldown)
            {
                StartCharging();
            }
            else
            {
                // Normal following behavior
                navAgent.SetDestination(player.position);
            }
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        
    }
    void StartCharging()
    {
        isCharging = true;
        chargeTimer = 0f;
        cooldownTimer = 0f;
        navAgent.angularSpeed = 60;
        // Calculate charge direction towards player
        chargeDirection = (player.position - transform.position).normalized;
    }

    void StopCharging()
    {
        isCharging = false;
        chargeTimer = 0f;
        navAgent.angularSpeed = 120;
    }
}
