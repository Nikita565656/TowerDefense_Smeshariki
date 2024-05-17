using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // ������ �������� ������
    public Transform spawnPoint; // ������� ������ ������
    public int waveSize = 5; // ������ �����
    public int maxWaves = 10; // ������������ ���������� ����
    public float timeBetweenWaves = 5f; // ����� ����� �������
    public float timeBetweenSpawns = 1f; // ����� ����� �������� ������

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
            // �������� ������ �� ������� ������� �������
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
