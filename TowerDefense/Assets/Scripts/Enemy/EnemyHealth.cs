using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyData enemyData;
    public UnitData unitData;
    public CurrencyData currencyData;
    private int currentHealth;

    private void Start()
    {
        currentHealth = enemyData.health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currencyData.coins += unitData.reward;
            Destroy(gameObject);
        }
    }
}
