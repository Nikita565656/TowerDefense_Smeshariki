using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Массив префабов врагов
    public Transform spawnPoint; // Позиция спавна врагов
    public int waveSize = 5; // Размер волны
    public int maxWaves = 10; // Максимальное количество волн
    public float timeBetweenWaves = 5f; // Время между волнами
    public float timeBetweenSpawns = 1f; // Время между спавнами врагов

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        for (int wave = 0; wave < maxWaves; wave++)
        {
            for (int i = 0; i < waveSize; i++)
            {
                SpawnAllEnemies();
                yield return new WaitForSeconds(timeBetweenSpawns);
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private void SpawnAllEnemies()
    {
        foreach (GameObject enemyPrefab in enemyPrefabs)
        {
            // Спавните врагов на позиции пустого объекта
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
