using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int damage = 1;
    public float lifetime = 5f;

    private void Start()
    {
        // Destroy the projectile after lifetime seconds
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider col)
    {
        // Check if the hit object has a health component
        EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.GetHit(damage);
        }

        // Destroy the projectile on impact
        Destroy(gameObject);
    }
} 