using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public UnitData unitData; // ��������� �� ��� ����
    public GameObject unitPrefab; // ��������� �� ������ ����
    public Button spawnButton; // ��������� �� ������ ������
    public Transform startPoint; // ��������� ����� ���� ����
    public Transform endPoint; // ʳ����� ����� ���� ����
    public Text coinText; // ��������� �� �������� ���� ��� �����

    private float coins; // ʳ������ �����

    private void Start()
    {
        spawnButton.onClick.AddListener(SpawnUnit);
        UpdateCoinText();
    }

    private void Update()
    {
        // ������ ������ ����� �������
        coins += Time.deltaTime;
        UpdateCoinText();
    }

    private void SpawnUnit()
    {
        // ����������, �� ������� ����� ��� ��������� ����
        if (coins >= unitData.cost)
        {
            // ³������ ������� ���� �� ������� �����
            coins -= unitData.cost;

            // ��������� ������ ���� � �������
            GameObject unitObject = Instantiate(unitPrefab, startPoint.position, Quaternion.identity);
            unitObject.name = "Unit";

            // ������ ������ ���� � ����������� ����
            UnitMovement unitMover = unitObject.GetComponent<UnitMovement>();
            unitMover.startPoint = startPoint.position;
            unitMover.endPoint = endPoint.position;
            unitMover.speed = unitData.movementSpeed;

            UpdateCoinText();
        }
    }

    private void UpdateCoinText()
    {
        // ��������� �������� ���� ��� �����
        coinText.text = coins.ToString();
    }
}
