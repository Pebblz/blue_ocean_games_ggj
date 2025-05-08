using UnityEngine;

public class EnemyAttackHitBox : MonoBehaviour
{
    [SerializeField, Tooltip("Damage done by attack")] int damage = 1;
    private void OnTriggerEnter(Collider col)
    {
        PlayerStats stats = col.GetComponent<PlayerStats>();
        if(stats != null )
        {
            stats.DamagePlayer(damage);
        }
    }
}
