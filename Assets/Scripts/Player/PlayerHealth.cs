using UnityEngine;

/* 
Remove later Moved to Player Stats project 
 
 
 
 
 
 */















public class PlayerHealth : MonoBehaviour
{
    [SerializeField, Tooltip("Players health")] protected int health = 6;
    protected int startHealth;
    public int Health { get { return health; } set { health = value; } }
    [SerializeField, Tooltip("How long the player can't take damage for")] float iFrameTime = .1f;
    private float currentIframes;
    private Rigidbody rb;
    private bool isDead = false;
    void Start()
    {
        startHealth = health;
        rb = GetComponent<Rigidbody>();

        //this is for when ever we have a healthbar
        //healthUI = FindFirstObjectByType<HealthUI>();
    }
    void Update()
    {
        //Iframes
        if (currentIframes > -1f)
        {
            currentIframes -= Time.deltaTime;
        }
    }
    public void DamagePlayer(int lostHealth)
    {
        if (currentIframes <= 0)
        {
            //lose health
            health -= lostHealth;

            //update health UI
            // healthUI.UpdateHealth(health);

            //startIframes
            currentIframes = iFrameTime;
            //if player dies, he dies
            if (health <= 0)
            {
                isDead = true;
                KillPlayer();
            }
        }
    }
    public void KillPlayer()
    {
        rb.linearVelocity = Vector2.zero;
    }
    public bool MaxHealth()
    {
        if (health == startHealth)
            return true;
        else
        {
            return false;
        }
    }
    public void GainHealth(int amount)
    {
        if (health + amount > startHealth)
            health = startHealth;
        else
        {
            health += startHealth;
        }
        //update health UI
        // healthUI.UpdateHealth(health);
    }
    public void SetHealth(int amount)
    {
        if (amount > startHealth || amount == 0)
            health = startHealth;
        else
            health = amount;
        //update health UI
        //healthUI.UpdateHealth(health);
    }
}
