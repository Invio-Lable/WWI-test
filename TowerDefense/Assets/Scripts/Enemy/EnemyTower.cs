using UnityEngine;
using UnityEngine.UI;

public class EnemyTower : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Text healthText;
    public GameObject victoryUI;
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
        gameManager.ShowVictoryUI();
        Destroy(gameObject);
    }
}
