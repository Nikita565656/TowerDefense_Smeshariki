using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public float spawnInterval = 3f; 
    public int maxEnemies = 10; 
    private int currentEnemies = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (currentEnemies < maxEnemies)
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                currentEnemies++;
                Instantiate(enemyPrefab1, transform.position, Quaternion.identity);
                currentEnemies++;
                Instantiate(enemyPrefab2, transform.position, Quaternion.identity);
                currentEnemies++;

            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
