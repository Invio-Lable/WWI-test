using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public UnitData unitData; // Посилання на дані юніта
    public GameObject unitPrefab; // Посилання на префаб юніта
    public Button spawnButton; // Посилання на кнопку спавну
    public Transform startPoint; // Початкова точка руху юніта
    public Transform endPoint; // Кінцева точка руху юніта
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
        if (coins >= unitData.cost)
        {
            // Віднімаємо вартість юніта від кількості монет
            coins -= unitData.cost;

            // Створюємо нового юніта з префаба
            GameObject unitObject = Instantiate(unitPrefab, startPoint.position, Quaternion.identity);
            unitObject.name = "Unit";

            // Додаємо скрипт руху і налаштовуємо його
            UnitMovement unitMover = unitObject.GetComponent<UnitMovement>();
            unitMover.startPoint = startPoint.position;
            unitMover.endPoint = endPoint.position;
            unitMover.speed = unitData.movementSpeed;

            UpdateCoinText();
        }
    }

    private void UpdateCoinText()
    {
        // Оновлюємо текстове поле для монет
        coinText.text = coins.ToString();
    }
}
