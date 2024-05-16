using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Text healthText; // Текстовий елемент для відображення здоров'я башти

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
        // Додайте логіку руйнування башні
        Debug.Log("Tower Destroyed!");
    }
}
