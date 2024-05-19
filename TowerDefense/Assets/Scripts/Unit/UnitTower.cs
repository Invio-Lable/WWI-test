using UnityEngine;
using UnityEngine.UI;

public class UnitTower : MonoBehaviour
{
    public float maxHealth = 50f;
    private float currentHealth;
    public Text healthText;
    public GameObject defeatUI;
    public GameManager gameManager;

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
        gameManager.ShowDefeatUI();
        Destroy(gameObject);
    }

    public void IncreaseHealth(int amount)
    {
        maxHealth += amount;
    }
}
