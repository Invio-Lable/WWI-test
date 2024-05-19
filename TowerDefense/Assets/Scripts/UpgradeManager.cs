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
    public GameData gameData;

    private float baseSpeedUpgradeCost = 25f;
    private float baseHealthUpgradeCost = 20f;
    private float baseBonusUpgradeCost = 50f;

    private void Start()
    {
        speedUpgradeButton.onClick.AddListener(UpgradeSpeed);
        healthUpgradeButton.onClick.AddListener(UpgradeHealth);
        bonusUpgradeButton.onClick.AddListener(UpgradeBonus);
        UpdateUpgradeCosts();
    }

    private void UpgradeSpeed()
    {
        int cost = Mathf.RoundToInt(baseSpeedUpgradeCost * Mathf.Pow(1.3f, gameData.productionUpgradeLevel));
        if (playerCurrency.TakeCoins(cost))
        {
            gameData.productionUpgradeLevel++;
            coinManager.IncreaseProductionSpeed(0.02f);
            UpdateUpgradeCosts();
        }
    }

    private void UpgradeHealth()
    {
        int cost = Mathf.RoundToInt(baseHealthUpgradeCost * Mathf.Pow(1.3f, gameData.healthUpgradeLevel));
        if (playerCurrency.TakeCoins(cost))
        {
            gameData.healthUpgradeLevel++;
            unitTower.IncreaseHealth(5);
            UpdateUpgradeCosts();
        }
    }

    private void UpgradeBonus()
    {
        int cost = Mathf.RoundToInt(baseBonusUpgradeCost * Mathf.Pow(1.3f, gameData.bonusUpgradeLevel));
        if (playerCurrency.TakeCoins(cost))
        {
            gameData.bonusUpgradeLevel++;
            coinManager.AddBonus(1);
            UpdateUpgradeCosts();
        }
    }

    private void UpdateUpgradeCosts()
    {
        speedUpgradeCostText.text = Mathf.RoundToInt(baseSpeedUpgradeCost * Mathf.Pow(1.3f, gameData.productionUpgradeLevel)).ToString();
        healthUpgradeCostText.text = Mathf.RoundToInt(baseHealthUpgradeCost * Mathf.Pow(1.3f, gameData.healthUpgradeLevel)).ToString();
        bonusUpgradeCostText.text = Mathf.RoundToInt(baseBonusUpgradeCost * Mathf.Pow(1.3f, gameData.bonusUpgradeLevel)).ToString();
    }
}