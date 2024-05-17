using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text coinText;
    public float productionInterval = 1;
    private float coins;
    private float bonus = 0;

    private void Start()
    {
        coins = bonus;
        UpdateCoinText();
    }

    private void Update()
    {
        coins += Time.deltaTime / productionInterval; 
        UpdateCoinText();
    }

    public bool SpendCoins(int amount)
    {
        if (Mathf.FloorToInt(coins) >= amount)
        {
            coins -= amount;
            UpdateCoinText();
            return true;
        }
        return false;
    }

    public void UpdateCoinText()
    {
        coinText.text = coins.ToString("F0");
    }

    public float GetCoins()
    {
        return coins;
    }

    public void AddBonus(float amount)
    {
        bonus += amount;
        coins = bonus;
        UpdateCoinText();
    }
    public void IncreaseProductionSpeed(float amount)
    {
        productionInterval -= amount;
        if (productionInterval < 0.1f)
        {
            productionInterval = 0.1f;
        }
    }

}
