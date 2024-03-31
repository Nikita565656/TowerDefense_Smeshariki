using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform[] waypoints; // Массив точек маршрута
    public float speed = 2.0f; // Скорость движения
    private int waypointIndex = 0; // Индекс текущей точки маршрута

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position; // Начальная позиция
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);

        // Проверка достижения текущей точки маршрута
        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1; // Переход к следующей точке маршрута
        }

        // Если достигнута последняя точка маршрута, возвращаемся к первой
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
