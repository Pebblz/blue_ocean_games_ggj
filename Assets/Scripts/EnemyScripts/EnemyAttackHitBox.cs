using UnityEngine;

public class EnemyAttackHitBox : MonoBehaviour
{
    [SerializeField, Tooltip("Damage done by attack")] int damage = 1;
    private void OnTriggerEnter(Collider col)
    {
        PlayerHealth pHealth = col.GetComponent<PlayerHealth>();
        if(pHealth != null )
        {
            //make this work with what josh is doing later
            //he moved the health methods to his script
            //pHealth.DamagePlayer(damage);
        }
    }
}
