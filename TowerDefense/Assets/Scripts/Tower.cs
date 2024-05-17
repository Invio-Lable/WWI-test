using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Text healthText;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            DestroyTower();
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString("F0");
    }

    private void DestroyTower()
    {
        Debug.Log("Tower Destroyed!");
    }

    public void IncreaseHealth(int amount)
    {
        maxHealth += amount;
    }

}