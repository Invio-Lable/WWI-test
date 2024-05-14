using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public UnitData unitData;
    private int currentHealth;

    private void Start()
    {
        currentHealth = unitData.health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}