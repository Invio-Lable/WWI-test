using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public UnitData unitData; // Посилання на дані юніта
    public GameObject unitPrefab; // Посилання на префаб юніта
    public Button spawnButton; // Посилання на кнопку спавну
    public Transform startPoint; // Початкова точка руху юніта
    public Transform towerTransform; // Додано змінну для вежі
    public Text coinText; // Посилання на текстове поле для монет

    private float coins; // Кількість монет

    private void Start()
    {
        spawnButton.onClick.AddListener(SpawnUnit);
        UpdateCoinText();
    }

    private void Update()
    {
        // Додаємо монети кожну секунду
        coins += Time.deltaTime;
        UpdateCoinText();
    }

    private void SpawnUnit()
    {
        // Перевіряємо, чи вистачає монет для створення юніта
        if (Mathf.FloorToInt(coins) >= unitData.cost)
        {
            // Віднімаємо вартість юніта від кількості монет
            coins -= unitData.cost;

            // Створюємо нового юніта з префаба
            GameObject unitObject = Instantiate(unitPrefab, startPoint.position, Quaternion.identity);
            unitObject.name = "Unit";

            // Додаємо скрипти руху та атаки і налаштовуємо їх
            UnitMovement unitMover = unitObject.GetComponent<UnitMovement>();
            unitMover.startPoint = startPoint.position;
            unitMover.towerTransform = towerTransform; // Налаштовуємо вежу
            unitMover.speed = unitData.movementSpeed;

            UnitAttack unitAttack = unitObject.GetComponent<UnitAttack>();
            unitAttack.unitData = unitData;

            UpdateCoinText();
        }
    }

    private void UpdateCoinText()
    {
        // Оновлюємо текстове поле для монет
        coinText.text = coins.ToString("F0");
    }
}
