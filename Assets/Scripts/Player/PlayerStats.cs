using UnityEngine;


public enum PLAYER_STATS
{
    HEALTH,
    DEFENSE,
    STAMINA,
    STRENGTH
}


public class PlayerStats : MonoBehaviour
{


    /*
     Health   -- Health of the player
     Defense  -- incoming damage reduction
     Stamina  -- how much inventory can be held


     */
    [SerializeField, Tooltip("Players health")] protected int health = 6;
    protected int startHealth;
    [SerializeField, Tooltip("Players defense")] protected int defense = 6;
    [SerializeField, Tooltip("Players stamina")] protected int stamina = 6;
    [SerializeField, Tooltip("Players stamina")] protected int strength = 6;

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

    #region HEALTH
    public void DamagePlayer(int lostHealth)
    {
        if (currentIframes <= 0)
        {

            //TODO: Incoprorate Defense stat into calculation
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
    #endregion

    #region STAT_MANIPULATION
    public void addStat(PLAYER_STATS stat, int amount)
    {
        switch (stat)
        {
            case PLAYER_STATS.HEALTH:
                if(startHealth + amount <= 0)
                    startHealth = 1;
                if (health + amount <= 0)
                    health = 1;
                else
                {
                    startHealth += amount;
                    GainHealth(amount);
                }
                break;
            case PLAYER_STATS.DEFENSE:
                defense += amount;
                break;
            case PLAYER_STATS.STAMINA:
                stamina += amount;
                break;
            case PLAYER_STATS.STRENGTH:
                strength += amount;
                break;
        }

    }

    public void removeStat(PLAYER_STATS stat, int amount)
    {
        switch (stat)
        {
            case PLAYER_STATS.HEALTH:
                if (health - amount <= 0)
                    health = 1;
                else
                    health -= amount;
                startHealth -= amount;
                break;
            case PLAYER_STATS.DEFENSE:
                defense -= amount;
                break;
            case PLAYER_STATS.STAMINA:
                stamina -= amount;
                break;
            case PLAYER_STATS.STRENGTH:
                strength += amount;
                break;
        }

    }
    #endregion

    #region PLAYER_ATTACK_DAMAGE
    public int getPlayerDamage()
    {
        return this.strength;
    }
    
    #endregion
}
