using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    //for hearts
    [SerializeField] int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    //for healthBar
    [SerializeField] Slider slider;
    [SerializeField] Gradient grad;
    [SerializeField] Image fill;
    int maxHealth;
    private void Start()
    {
        UpdateHealthImage(health);

        maxHealth = Mathf.RoundToInt(slider.value);
    }

    public void UpdateHealthImage(int newHealthVal)
    {
        health = newHealthVal;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] == null)
                return;
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public void UpdateHealthBar(int value)
    {
        if (value >= 0)
        {
            slider.value = value;
        }
        if (value > 0)
        {
            fill.color = ColorFromGradient(maxHealth / value);
        }
    }
    Color ColorFromGradient(float value)
    {
        return grad.Evaluate(value);
    }
}
