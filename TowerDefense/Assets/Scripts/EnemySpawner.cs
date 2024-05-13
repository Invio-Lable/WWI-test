using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyData> enemyDatas; // Список з даними про ворогів
    public List<GameObject> enemyPrefabs; // Список з префабами ворогів
    public Transform[] spawnPoints; // Масив точок спавну
    public Transform endPoint; // Кінцева точка руху ворога
    public int maxEnemiesPerSpawn = 3; // Максимальна кількість ворогів за один спавн
    public float spawnInterval = 7f; // Інтервал між спавнами

    private void Start()
    {
        // Починаємо процес спавну ворогів
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Вибираємо випадкову точку спавну
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Вибираємо випадкову кількість ворогів для спавну
            int numEnemies = Random.Range(1, maxEnemiesPerSpawn + 1);

            for (int i = 0; i < numEnemies; i++)
            {
                // Вибираємо випадкові дані ворога
                int randomIndex = Random.Range(0, enemyDatas.Count);
                EnemyData enemyData = enemyDatas[randomIndex];

                // Створюємо нового ворога з випадкового префаба
                GameObject enemyPrefab = enemyPrefabs[randomIndex];
                GameObject enemyObject = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemyObject.name = "Enemy";

                // Додаємо скрипт руху і налаштовуємо його
                UnitMovement enemyMover = enemyObject.GetComponent<UnitMovement>();
                enemyMover.startPoint = spawnPoint.position;
                enemyMover.endPoint = endPoint.position;
                enemyMover.speed = enemyData.movementSpeed;
            }

            // Чекаємо інтервал спавну перед наступним спавном
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
