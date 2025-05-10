using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField, Tooltip("The Enemy health")] int health = 3;
    [SerializeField, Tooltip("This will add 3DText to the damage of an enemy")] GameObject threeDTextPrefab;
    [SerializeField] float iFrameCount = .2f;
    bool canBeHit = true;
    public void GetHit(int damage)
    {
        if (!canBeHit) return;
        //subtracted health from the amount of damage you do
        health -= damage;
        if ( threeDTextPrefab != null)
        {
            GameObject g = Instantiate(threeDTextPrefab, transform.position + new Vector3(Random.Range(-.2f, .2f), Random.Range(.2f, .5f), Random.Range(-.2f, .2f)),Quaternion.identity);
            g.GetComponent<ThreeDText>().textMeshPro.text = damage.ToString();
        }
        if (health <= 0)
        {
            //we can change this later to play an animation or make a lootbag when killed
            Destroy(gameObject);
        }
        canBeHit = false;
        Invoke("IframesOver", iFrameCount);
    }
    void IframesOver()
    {
        canBeHit = true;
    }
}