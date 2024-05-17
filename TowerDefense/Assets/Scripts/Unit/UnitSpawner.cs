using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public UnitData unitData;
    public GameObject unitPrefab;
    public Button spawnButton;
    public Transform startPoint;
    public Transform towerTransform;
    public CoinManager coinManager;

    private void Start()
    {
        spawnButton.onClick.AddListener(SpawnUnit);
    }

    private void SpawnUnit()
    {
        // Перевіряємо, чи вистачає монет для створення юніта через CoinManager
        if (coinManager.SpendCoins(unitData.cost))
        {
            // Створюємо нового юніта з префаба
            GameObject unitObject = Instantiate(unitPrefab, startPoint.position, Quaternion.identity);
            unitObject.name = "Unit";

            // Додаємо скрипти руху та атаки і налаштовуємо їх
            UnitMovement unitMover = unitObject.GetComponent<UnitMovement>();
            unitMover.startPoint = startPoint.position;
            unitMover.towerTransform = towerTransform;
            unitMover.speed = unitData.movementSpeed;

            UnitAttack unitAttack = unitObject.GetComponent<UnitAttack>();
            unitAttack.unitData = unitData;
        }
    }
}
