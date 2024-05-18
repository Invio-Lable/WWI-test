using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrency : MonoBehaviour
{
    public CurrencyData currencyData;
    public Text coinsText;

    private void Start()
    {
        UpdateCoinsText();
    }

    public void AddCoins(int amount)
    {
        currencyData.coins += amount;
        UpdateCoinsText();
    }

    public bool TakeCoins(int amount)
    {
        if (currencyData.coins >= amount)
        {
            currencyData.coins -= amount;
            UpdateCoinsText();
            return true;
        }
        return false;
    }

    private void UpdateCoinsText()
    {
        coinsText.text = currencyData.coins.ToString();
    }
}
