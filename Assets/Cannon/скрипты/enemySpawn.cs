using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // ������ �����, ������� ����� ��������� ����� ��������� Unity
    public GameObject enemyPrefab;

    // ����� ������ �����
    public float spawnInterval = 3.0f;

    // ��������� ����� ������
    private float nextSpawnTime;

    void Update()
    {
        // ���� ������� ����� ������ ��� ����� ������� ���������� ������
        if (Time.time >= nextSpawnTime)
        {
            // ������� �����
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // ��������� ����� ���������� ������
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}
