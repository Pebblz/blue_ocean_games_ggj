using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int damage = 1;
    public float lifetime = 5f;
    public bool damageEnemy = true;
    public bool destroyOnHit = true;
    private void Start()
    {
        // Destroy the projectile after lifetime seconds
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider col)
    {
        // Check if the hit object has a health component
        EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
        if (enemyHealth != null && damageEnemy)
        {
            enemyHealth.GetHit(damage);
        }
        if (col.transform.parent != null)
        {
            PlayerStats stats = col.transform.parent.GetComponent<PlayerStats>();
            if (stats != null)
            {
                stats.DamagePlayer(damage);
            }
        }
        // Destroy the projectile on impact
        if (!col.isTrigger && destroyOnHit)
        {
            Destroy(gameObject);
        }
    }
} 