using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyData> enemyDatas;
    public List<GameObject> enemyPrefabs;
    public Transform[] spawnPoints;
    public Transform towerTransform;
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
                int randomIndex = Random.Range(0, enemyDatas.Count);
                EnemyData enemyData = enemyDatas[randomIndex];

                GameObject enemyPrefab = enemyPrefabs[randomIndex];
                GameObject enemyObject = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemyObject.name = "Enemy";

                EnemyMovement enemyMover = enemyObject.GetComponent<EnemyMovement>();
                enemyMover.startPoint = spawnPoint.position;
                enemyMover.towerTransform = towerTransform;
                enemyMover.speed = enemyData.movementSpeed;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
