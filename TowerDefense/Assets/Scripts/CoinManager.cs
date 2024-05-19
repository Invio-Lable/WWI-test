using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text coinText;
    public GameData gameData;

    private float coins;

    private void Start()
    {
        coins = gameData.bonus;
        UpdateCoinText();
    }

    private void Update()
    {
        coins += Time.deltaTime / gameData.productionInterval;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = coins.ToString("F0");
    }

    public bool TakeCoins(int amount)
    {
        if (Mathf.FloorToInt(coins) >= amount)
        {
            coins -= amount;
            UpdateCoinText();
            return true;
        }
        return false;
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

    public void AddBonus(float amount)
    {
        gameData.bonus += amount;
        coins = gameData.bonus;
        UpdateCoinText();
    }

    public void IncreaseProductionSpeed(float amount)
    {
        gameData.productionInterval -= amount;
        if (gameData.productionInterval < 0.1f)
        {
            gameData.productionInterval = 0.1f;
        }
    }
}
