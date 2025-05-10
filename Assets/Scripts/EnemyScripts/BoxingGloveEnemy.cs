using UnityEngine;
using UnityEngine.AI;
using System.Collections;

/// <summary>
/// Enemy that uses NavMesh to move around and shoots a projectile that travels a certain distance and returns like a boomerang
/// </summary>
public class BoxingGloveEnemy : MonoBehaviour, IEnemy
{
    [Header("Projectile Settings")]
    [Tooltip("The projectile prefab to be shot")]
    public GameObject projectilePrefab;

    [Tooltip("How far the projectile will travel before returning")]
    public float maxDistance = 10f;

    [Tooltip("How far the projectile will travel in melee range")]
    public float meleeMaxDistance = 3f;

    [Tooltip("How fast the projectile moves")]
    public float projectileSpeed = 5f;

    [Tooltip("How long to wait between shots")]
    public float shootCooldown = 2f;

    [Tooltip("How far the enemy needs to be from the player to shoot")]
    public float shootRange = 10f;

    [Header("Melee Settings")]
    [Tooltip("How close the player needs to be for a melee attack")]
    public float meleeRange = 2f;

    [Header("References")]
    [Tooltip("The point where projectiles will spawn")]
    public Transform shootPoint;

    private float nextShootTime;
    private GameObject currentProjectile;
    private bool isProjectileReturning;
    private NavMeshAgent navAgent;
    private Transform player;

    void Start()
    {
        // Initialize the next shoot time
        nextShootTime = Time.time;

        // Get or add NavMeshAgent component
        navAgent = GetComponent<NavMeshAgent>();

        // Configure NavMeshAgent
        navAgent.stoppingDistance = shootRange * 0.8f; // Stop slightly before shoot range
    }

    void Update()
    {
        if (player == null) return;

        // Check if player is in detection range
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Look at player
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        directionToPlayer.y = 0; // Keep rotation only on Y axis
        if (directionToPlayer != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }

        if (distanceToPlayer > meleeRange)
        {
            navAgent.SetDestination(player.position);
        }
        else
        {
            navAgent.ResetPath();
        }

        // Check if it's time to shoot again
        if (Time.time >= nextShootTime && currentProjectile == null && distanceToPlayer <= shootRange)
        {
            ShootProjectile(distanceToPlayer <= meleeRange);
        }

        // Handle returning projectile
        if (currentProjectile != null && isProjectileReturning)
        {
            // Move projectile back to enemy
            Vector3 directionToEnemy = (transform.position - currentProjectile.transform.position).normalized;
            currentProjectile.transform.position += directionToEnemy * projectileSpeed * Time.deltaTime;

            // Check if projectile has returned
            if (Vector3.Distance(currentProjectile.transform.position, transform.position) < 0.5f)
            {
                Destroy(currentProjectile);
                currentProjectile = null;
                isProjectileReturning = false;
            }
        }
    }

    void ShootProjectile(bool isMeleeRange)
    {
        // Create the projectile
        currentProjectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        
        // Start the projectile movement coroutine with appropriate range
        StartCoroutine(MoveProjectile(isMeleeRange ? meleeMaxDistance : maxDistance));
        
        // Set the next shoot time
        nextShootTime = Time.time + shootCooldown;
    }

    IEnumerator MoveProjectile(float targetDistance)
    {
        Vector3 startPosition = currentProjectile.transform.position;
        Vector3 direction = transform.forward;
        float distanceTraveled = 0f;

        // Move projectile forward until it reaches max distance
        while (distanceTraveled < targetDistance && currentProjectile != null)
        {
            currentProjectile.transform.position += direction * projectileSpeed * Time.deltaTime;
            distanceTraveled = Vector3.Distance(startPosition, currentProjectile.transform.position);
            yield return null;
        }

        // Start returning if projectile still exists
        if (currentProjectile != null)
        {
            isProjectileReturning = true;
        }
    }

    public void SetPlayer(Transform t)
    {
        player = t;
    }
}
