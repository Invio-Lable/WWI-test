using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public UnitData unitData;
    public Button spawnButton;
    public Transform startPoint;
    public Transform endPoint;

    private void Start()
    {
        spawnButton.onClick.AddListener(SpawnUnit);
    }

    private void SpawnUnit()
    {
        GameObject unitObject = new GameObject("Unit");
        SpriteRenderer spriteRenderer = unitObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = unitData.sprite;

        UnitMovement unitMover = unitObject.AddComponent<UnitMovement>();
        unitMover.startPoint = startPoint.position;
        unitMover.endPoint = endPoint.position;
        unitMover.speed = unitData.movementSpeed;
    }
}