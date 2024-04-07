using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Префаб врага, который можно настроить через инспектор Unity
    public GameObject enemyPrefab;

    // Время спавна врага
    public float spawnInterval = 3.0f;

    // Следующее время спавна
    private float nextSpawnTime;

    void Update()
    {
        // Если текущее время больше или равно времени следующего спавна
        if (Time.time >= nextSpawnTime)
        {
            // Спавним врага
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Обновляем время следующего спавна
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}
