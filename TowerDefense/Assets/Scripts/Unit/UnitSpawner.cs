using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public UnitData unitData; // ��������� �� ��� ����
    public GameObject unitPrefab; // ��������� �� ������ ����
    public Button spawnButton; // ��������� �� ������ ������
    public Transform startPoint; // ��������� ����� ���� ����
    public Transform endPoint; // ʳ����� ����� ���� ����

    private void Start()
    {
        spawnButton.onClick.AddListener(SpawnUnit);
    }

    private void SpawnUnit()
    {
        // ��������� ������ ���� � �������
        GameObject unitObject = Instantiate(unitPrefab, startPoint.position, Quaternion.identity);
        unitObject.name = "Unit";

        // ������ ������ ���� � ����������� ����
        UnitMovement unitMover = unitObject.GetComponent<UnitMovement>();
        unitMover.startPoint = startPoint.position;
        unitMover.endPoint = endPoint.position;
        unitMover.speed = unitData.movementSpeed;
    }
}
