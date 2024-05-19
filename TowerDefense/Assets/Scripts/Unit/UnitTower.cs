using UnityEngine;
using UnityEngine.UI;

public class UnitTower : MonoBehaviour
{
    public GameData gameData;
    public Text healthText;
    public GameObject defeatUI;
    public GameManager gameManager;

    private float currentHealth;

    private void Start()
    {
        currentHealth = gameData.towerHealth;
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
        gameData.towerHealth += amount;
    }
}
