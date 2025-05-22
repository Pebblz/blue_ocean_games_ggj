using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayerHitBoxDamageScript : MonoBehaviour
{
    private PlayerStats stats;

    private void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyHealth health = other.GetComponent<EnemyHealth>();
            health.GetHit(stats.getPlayerDamage());
        }
    }
}
