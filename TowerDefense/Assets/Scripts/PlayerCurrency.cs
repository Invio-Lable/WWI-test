using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrency : MonoBehaviour
{
    public int coins = 0;
    public Text coinsText;

    private void Start()
    {
        UpdateCoinsText();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateCoinsText();
    }

    public bool TakeCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            UpdateCoinsText();
            return true;
        }
        return false;
    }

    private void UpdateCoinsText()
    {
        coinsText.text = coins.ToString();
    }
}
