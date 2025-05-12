using UnityEngine;

public class EnemyAttackHitBox : MonoBehaviour
{
    [SerializeField, Tooltip("Damage done by attack")] int damage = 1;
    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.parent != null)
        {
            PlayerStats stats = col.transform.parent.GetComponent<PlayerStats>();
            if (stats != null)
            {
                stats.DamagePlayer(damage);
            }
        }
    }
}
