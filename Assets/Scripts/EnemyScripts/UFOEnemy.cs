using System.Collections;
using UnityEngine;

public class UFOEnemy : MonoBehaviour, IEnemy
{
    Transform player;


    [Header("Target Settings")]
    [SerializeField] private float attackRange = 15f;

    [Header("Combat Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private int damage = 1;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float hoverHeight = 5f;
    [SerializeField] private float hoverAmplitude = 0.5f;
    [SerializeField] private float hoverFrequency = 1f;

    private bool canShoot = true;
    private float distanceToPlayer;
    private float hoverOffset;

    private void Start()
    {
        player = Player.Instance.GetComponent<Transform>();
        // Random start phase for hover
        hoverOffset = Random.Range(0f, 2f * Mathf.PI);
        // Set initial height to hoverHeight
        transform.position = new Vector3(transform.position.x, hoverHeight, transform.position.z);
    }
    
    public void SetPlayer(Transform t)
    {
        player = t;
    }
    private void Update()
    {
        if (player == null) return;

        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Update hover position using hoverHeight as the base
        float newY = hoverHeight + Mathf.Sin((Time.time + hoverOffset) * hoverFrequency) * hoverAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Normal combat behavior
        if (distanceToPlayer <= attackRange)
        {
            // Stop moving and face the player
            FaceTarget();

            // Shoot if cooldown is ready
            if (canShoot)
            {
                StartCoroutine(Shoot());
            }
        }
        else
        {
            // Move towards player if too far
            MoveTowardsPlayer();
        }

    }
    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        FaceTarget();
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

        // Calculate direction to player
        Vector3 directionToPlayer = (player.position - firePoint.position).normalized;

        // Create and setup projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(directionToPlayer));
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = directionToPlayer * projectileSpeed;
        }

        // Add damage component if it doesn't exist
        ProjectileDamage projectileDamage = projectile.GetComponent<ProjectileDamage>();

        projectileDamage.damage = damage;

        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
