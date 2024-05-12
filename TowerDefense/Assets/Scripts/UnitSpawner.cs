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
        unitObject.transform.position = startPoint.position;
        SpriteRenderer spriteRenderer = unitObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = unitData.sprite;

        // Додаємо компонент Rigidbody2D
        Rigidbody2D rb = unitObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Вимикаємо гравітацію

        // Додаємо компонент Collider2D
        CircleCollider2D collider = unitObject.AddComponent<CircleCollider2D>();
        collider.isTrigger = false; // Встановлюємо, що це не тригер

        UnitMovement unitMover = unitObject.AddComponent<UnitMovement>();
        unitMover.startPoint = startPoint.position;
        unitMover.endPoint = endPoint.position;
        unitMover.speed = unitData.movementSpeed;
    }
}