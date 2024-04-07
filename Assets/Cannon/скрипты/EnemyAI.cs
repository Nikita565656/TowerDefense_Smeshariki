using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Отключение автоматического обновления пути и скорости движения
        agent.autoBraking = false;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Выбирает следующую точку из массива как цель и продолжает движение
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;

        // Выбирает следующую точку
        destPoint = (destPoint + 1) % points.Length;
    }

    void Update()
    {
        // Если близко к цели, переходит к следующей
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
