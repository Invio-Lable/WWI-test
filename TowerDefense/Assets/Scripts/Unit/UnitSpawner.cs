using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public UnitData unitData;
    public GameObject unitPrefab;
    public Button spawnButton;
    public Transform startPoint;
    public Transform enemyTowerTransform;
    public CoinManager coinManager;

    private void Start()
    {
        spawnButton.onClick.AddListener(SpawnUnit);
    }

    private void SpawnUnit()
    {
        if (coinManager.SpendCoins(unitData.cost))
        {
            GameObject unitObject = Instantiate(unitPrefab, startPoint.position, Quaternion.identity);
            unitObject.name = "Unit";

            UnitMovement unitMover = unitObject.GetComponent<UnitMovement>();
            unitMover.startPoint = startPoint.position;
            unitMover.towerTransform = enemyTowerTransform;
            unitMover.speed = unitData.movementSpeed;

            UnitAttack unitAttack = unitObject.GetComponent<UnitAttack>();
            unitAttack.unitData = unitData;
        }
    }
}
