using Unity.Cinemachine.Samples;
using UnityEngine;
using UnityEngine.AI;

public class MortarEnemy : MonoBehaviour
{
    [Header("Target Settings")]
    private Transform player;
    public float baseProjectileSpeed = 9f; // Significantly reduced base speed
    public Transform firePoint;

    [Header("Shooting Settings")]
    public GameObject mortarProjectile;
    public GameObject directProjectile;
    public float shootInterval = 3f;
    public float predictionTime = 0.1f; // Further reduced prediction time
    public float minDistance = 5f;
    public float maxDistance = 30f;
    public float closeRangeThreshold = 8f;

    private float nextShootTime;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // Find the player if not assigned
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        // Look at player
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0; // Keep the enemy upright
        transform.rotation = Quaternion.LookRotation(directionToPlayer);

        // Shoot if it's time
        if (Time.time >= nextShootTime)
        {
            ShootAtPlayer();
            nextShootTime = Time.time + shootInterval;
        }
        agent.SetDestination(player.position);
    }

    void ShootAtPlayer()
    {
        if (firePoint == null) return;

        // Predict player position
        Vector3 predictedPosition = PredictPlayerPosition();
        Vector3 direction = predictedPosition - firePoint.position;
        float distance = direction.magnitude;

        // Choose projectile and shooting method based on distance
        if (distance <= closeRangeThreshold)
        {
            ShootDirect(direction);
        }
        else if(distance <= maxDistance)
        {
            ShootMortar(direction, distance);
        }
    }

    void ShootDirect(Vector3 direction)
    {
        if (directProjectile == null) return;

        // Create the direct projectile
        GameObject projectile = Instantiate(directProjectile, firePoint.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            // Shoot directly at player with constant speed
            Vector3 velocity = direction.normalized * baseProjectileSpeed;
            rb.linearVelocity = velocity;
        }
    }

    void ShootMortar(Vector3 direction, float distance)
    {
        if (mortarProjectile == null) return;
        if (distance < 10)
        {
            baseProjectileSpeed = 10;
        }
        else
        {
            baseProjectileSpeed = 11;
        }
        // Calculate speed based on distance
        float adjustedSpeed = CalculateSpeedForDistance(distance);
        
        // Adjust angle based on distance
        float angle = CalculateAngleForDistance(distance);
        
        // Create the mortar projectile
        GameObject projectile = Instantiate(mortarProjectile, firePoint.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            Vector3 linearVelocity = CalculateArcVelocity(direction, angle, adjustedSpeed);
            rb.linearVelocity = linearVelocity;
        }
    }

    float CalculateSpeedForDistance(float distance)
    {
        // Clamp distance between min and max
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        
        // Calculate speed based on distance
        float normalizedDistance = (distance - minDistance) / (maxDistance - minDistance);
        float speedMultiplier = 0.9f + (normalizedDistance * 0.6f); // Range from 0.9 to 1.5
        
        return baseProjectileSpeed * speedMultiplier;
    }

    float CalculateAngleForDistance(float distance)
    {
        // Adjust angle based on distance
        float normalizedDistance = (distance - minDistance) / (maxDistance - minDistance);
        // More conservative angle range
        return Mathf.Lerp(25f, 35f, normalizedDistance);
    }

    Vector3 PredictPlayerPosition()
    {
        // Get player's current velocity
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        Vector3 predictedPosition = player.position;
        
        if (playerRb != null)
        {
            // Predict where the player will be based on their current velocity
            predictedPosition += playerRb.linearVelocity * predictionTime;
        }
        
        return predictedPosition;
    }

    Vector3 CalculateArcVelocity(Vector3 direction, float angle, float speed)
    {
        float angleRad = angle * Mathf.Deg2Rad;
        
        // Create the velocity vector
        Vector3 velocityVector = direction.normalized * speed;
        velocityVector.y = speed * Mathf.Sin(angleRad);
        
        return velocityVector;
    }
}