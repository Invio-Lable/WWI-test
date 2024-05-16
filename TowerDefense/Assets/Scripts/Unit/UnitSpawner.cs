using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public UnitData unitData; // ��������� �� ��� ����
    public GameObject unitPrefab; // ��������� �� ������ ����
    public Button spawnButton; // ��������� �� ������ ������
    public Transform startPoint; // ��������� ����� ���� ����
    public Transform towerTransform; // ������ ����� ��� ���
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
        if (Mathf.FloorToInt(coins) >= unitData.cost)
        {
            // ³������ ������� ���� �� ������� �����
            coins -= unitData.cost;

            // ��������� ������ ���� � �������
            GameObject unitObject = Instantiate(unitPrefab, startPoint.position, Quaternion.identity);
            unitObject.name = "Unit";

            // ������ ������� ���� �� ����� � ����������� ��
            UnitMovement unitMover = unitObject.GetComponent<UnitMovement>();
            unitMover.startPoint = startPoint.position;
            unitMover.towerTransform = towerTransform; // ����������� ����
            unitMover.speed = unitData.movementSpeed;

            UnitAttack unitAttack = unitObject.GetComponent<UnitAttack>();
            unitAttack.unitData = unitData;

            UpdateCoinText();
        }
    }

    private void UpdateCoinText()
    {
        // ��������� �������� ���� ��� �����
        coinText.text = coins.ToString("F0");
    }
}
