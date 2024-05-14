using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public UnitData unitData; // Посилання на дані юніта
    public GameObject unitPrefab; // Посилання на префаб юніта
    public Button spawnButton; // Посилання на кнопку спавну
    public Transform startPoint; // Початкова точка руху юніта
    public Transform endPoint; // Кінцева точка руху юніта

    private void Start()
    {
        spawnButton.onClick.AddListener(SpawnUnit);
    }

    private void SpawnUnit()
    {
        // Створюємо нового юніта з префаба
        GameObject unitObject = Instantiate(unitPrefab, startPoint.position, Quaternion.identity);
        unitObject.name = "Unit";

        // Додаємо скрипт руху і налаштовуємо його
        UnitMovement unitMover = unitObject.GetComponent<UnitMovement>();
        unitMover.startPoint = startPoint.position;
        unitMover.endPoint = endPoint.position;
        unitMover.speed = unitData.movementSpeed;
    }
}
