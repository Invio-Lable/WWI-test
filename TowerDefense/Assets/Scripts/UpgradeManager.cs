using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public Button speedUpgradeButton;
    public Button healthUpgradeButton;
    public Button bonusUpgradeButton;
    public Text speedUpgradeCostText;
    public Text healthUpgradeCostText;
    public Text bonusUpgradeCostText;

    public PlayerCurrency playerCurrency;
    public CoinManager coinManager;
    public UnitTower unitTower;

    private int productionUpgradeLevel = 0;
    private int healthUpgradeLevel = 0;
    private int bonusUpgradeLevel = 0;

    private float baseSpeedUpgradeCost = 25f;
    private float baseHealthUpgradeCost = 20;
    private float baseBonusUpgradeCost = 50;

    private void Start()
    {
        speedUpgradeButton.onClick.AddListener(UpgradeSpeed);
        healthUpgradeButton.onClick.AddListener(UpgradeHealth);
        bonusUpgradeButton.onClick.AddListener(UpgradeBonus);
        UpdateUpgradeCosts();
        Debug.Log("UpgradeManager initialized.");
    }

    private void UpgradeSpeed()
    {
        int cost = Mathf.RoundToInt(baseSpeedUpgradeCost * Mathf.Pow(1.3f, productionUpgradeLevel));
        Debug.Log($"Attempting to upgrade speed. Cost: {cost}, Player Coins: {playerCurrency.currencyData.coins}");
        if (playerCurrency.TakeCoins(cost))
        {
            productionUpgradeLevel++;
            coinManager.IncreaseProductionSpeed(0.02f);
            Debug.Log("Speed upgraded.");
            UpdateUpgradeCosts();
        }
        else
        {
            Debug.Log("Not enough coins to upgrade speed.");
        }
    }

    private void UpgradeHealth()
    {
        int cost = Mathf.RoundToInt(baseHealthUpgradeCost * Mathf.Pow(1.3f, healthUpgradeLevel));
        Debug.Log($"Attempting to upgrade health. Cost: {cost}, Player Coins: {playerCurrency.currencyData.coins}");
        if (playerCurrency.TakeCoins(cost))
        {
            healthUpgradeLevel++;
            unitTower.IncreaseHealth(5);
            Debug.Log("Health upgraded.");
            UpdateUpgradeCosts();
        }
        else
        {
            Debug.Log("Not enough coins to upgrade health.");
        }
    }

    private void UpgradeBonus()
    {
        int cost = Mathf.RoundToInt(baseBonusUpgradeCost * Mathf.Pow(1.3f, bonusUpgradeLevel));
        Debug.Log($"Attempting to upgrade bonus. Cost: {cost}, Player Coins: {playerCurrency.currencyData.coins}");
        if (playerCurrency.TakeCoins(cost))
        {
            bonusUpgradeLevel++;
            coinManager.AddBonus(1);
            Debug.Log("Bonus upgraded.");
            UpdateUpgradeCosts();
        }
        else
        {
            Debug.Log("Not enough coins to upgrade bonus.");
        }
    }

    private void UpdateUpgradeCosts()
    {
        speedUpgradeCostText.text = Mathf.RoundToInt(baseSpeedUpgradeCost * Mathf.Pow(1.3f, productionUpgradeLevel)).ToString();
        healthUpgradeCostText.text = Mathf.RoundToInt(baseHealthUpgradeCost * Mathf.Pow(1.3f, healthUpgradeLevel)).ToString();
        bonusUpgradeCostText.text = Mathf.RoundToInt(baseBonusUpgradeCost * Mathf.Pow(1.3f, bonusUpgradeLevel)).ToString();
        Debug.Log("Upgrade costs updated.");
    }
}
