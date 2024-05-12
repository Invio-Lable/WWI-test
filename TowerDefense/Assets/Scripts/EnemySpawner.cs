using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public EnemyData enemyData;
    public Transform[] spawnPoints;
    public Transform endPoint;
    public int maxEnemiesPerSpawn = 3;
    public float spawnInterval = 7f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            int numEnemies = Random.Range(1, maxEnemiesPerSpawn + 1);

            for (int i = 0; i < numEnemies; i++)
            {
                GameObject enemyObject = new GameObject("Enemy");
                SpriteRenderer spriteRenderer = enemyObject.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = enemyData.sprite;

                // Додаємо компонент Rigidbody2D
                Rigidbody2D rb = enemyObject.AddComponent<Rigidbody2D>();
                rb.gravityScale = 0; // Вимикаємо гравітацію

                // Додаємо компонент Collider2D
                CircleCollider2D collider = enemyObject.AddComponent<CircleCollider2D>();
                collider.isTrigger = false; // Встановлюємо, що це не тригер

                Vector3 spawnPosition = spawnPoint.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                enemyObject.transform.position = spawnPosition;

                UnitMovement enemyMover = enemyObject.AddComponent<UnitMovement>();
                enemyMover.startPoint = spawnPosition;
                enemyMover.endPoint = endPoint.position;
                enemyMover.speed = enemyData.movementSpeed;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
