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
    private float baseHealthUpgradeCost = 25f;
    private float baseBonusUpgradeCost = 25f;

    private void Start()
    {
        speedUpgradeButton.onClick.AddListener(UpgradeSpeed);
        healthUpgradeButton.onClick.AddListener(UpgradeHealth);
        bonusUpgradeButton.onClick.AddListener(UpgradeBonus);
        UpdateUpgradeCosts();
    }

    private void UpgradeSpeed()
    {
        int cost = Mathf.RoundToInt(baseSpeedUpgradeCost * Mathf.Pow(1.3f, productionUpgradeLevel));
        if (playerCurrency.TakeCoins(cost))
        {
            productionUpgradeLevel++;
            coinManager.IncreaseProductionSpeed(0.02f);
            UpdateUpgradeCosts();
        }
    }

    private void UpgradeHealth()
    {
        int cost = Mathf.RoundToInt(baseHealthUpgradeCost * Mathf.Pow(1.3f, healthUpgradeLevel));
        if (playerCurrency.TakeCoins(cost))
        {
            healthUpgradeLevel++;
            unitTower.IncreaseHealth(5);
            UpdateUpgradeCosts();
        }
    }

    private void UpgradeBonus()
    {
        int cost = Mathf.RoundToInt(baseBonusUpgradeCost * Mathf.Pow(1.3f, bonusUpgradeLevel));
        if (playerCurrency.TakeCoins(cost))
        {
            bonusUpgradeLevel++;
            coinManager.AddBonus(1);
            UpdateUpgradeCosts();
        }
    }

    private void UpdateUpgradeCosts()
    {
        speedUpgradeCostText.text = Mathf.Round(baseSpeedUpgradeCost * Mathf.Pow(1.3f, productionUpgradeLevel)).ToString();
        healthUpgradeCostText.text = Mathf.Round(baseHealthUpgradeCost * Mathf.Pow(1.3f, healthUpgradeLevel)).ToString();
        bonusUpgradeCostText.text = Mathf.Round(baseBonusUpgradeCost * Mathf.Pow(1.3f, bonusUpgradeLevel)).ToString();
    }
}