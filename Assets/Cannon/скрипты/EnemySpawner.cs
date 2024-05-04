using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага, который нужно спавнить
    public float spawnInterval = 3.0f; // Интервал спавна в секундах

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity); // Спавн врага
            yield return new WaitForSeconds(spawnInterval); // Пауза перед следующим спавном
        }
    }
}
