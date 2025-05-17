using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class RangedEnemy : MonoBehaviour, IEnemy
{
    [Header("Target Settings")]
    [SerializeField] private float attackRange = 15f;
    [SerializeField] private float minAttackRange = 5f;

    [Header("Combat Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private int damage = 1;

    [Header("Movement Settings")]
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float retreatDistance = 8f;

    private Transform player;
    private NavMeshAgent agent;
    private bool canShoot = true;
    private float distanceToPlayer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (player == null) return;

        distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        // Handle combat behavior
        if (distanceToPlayer <= attackRange && distanceToPlayer >= minAttackRange)
        {
            // Stop moving and face the player
            agent.isStopped = true;
            FaceTarget();
            
            // Shoot if cooldown is ready
            if (canShoot)
            {
                StartCoroutine(Shoot());
            }
        }
        else if (distanceToPlayer < minAttackRange)
        {
            // Retreat if too close
            Vector3 retreatDirection = (transform.position - player.position).normalized;
            Vector3 retreatPosition = transform.position + retreatDirection * retreatDistance;
            
            // Find the nearest valid position on the NavMesh
            NavMeshHit hit;
            if (NavMesh.SamplePosition(retreatPosition, out hit, retreatDistance, NavMesh.AllAreas))
            {
                agent.isStopped = false;
                agent.SetDestination(hit.position);
            }
        }
        else
        {
            // Move towards player if too far
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; // Keep rotation only on the horizontal plane
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        // Create and setup projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * projectileSpeed;
        }

        // Add damage component if it doesn't exist
        ProjectileDamage projectileDamage = projectile.GetComponent<ProjectileDamage>();
        if (projectileDamage == null)
        {
            projectileDamage = projectile.AddComponent<ProjectileDamage>();
        }
        projectileDamage.damage = damage;

        // Wait for fire rate cooldown
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public void SetPlayer(Transform t)
    {
        player = t;
    }
} 