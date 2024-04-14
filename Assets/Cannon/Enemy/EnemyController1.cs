using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController1 : MonoBehaviour
{
    [SerializeField] private Transform[] targetsPoints;
    private NavMeshAgent agent;
    private int currentIndex = 0;
    public EnemyData enemyData;
    private float currentSpeed;
    private float currentHp;
    private float currentDamage;

    void Start()
    {
        currentSpeed = enemyData.EnemySpeed;
        currentHp = enemyData.EnemyHp;
        currentDamage = enemyData.Enemydamage;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = currentSpeed;
        agent.SetDestination(targetsPoints[currentIndex].position);
    }

    
    void Update()
    {
        Movement();

    }
    private void Movement()
    {
        if (agent.remainingDistance < 0.01f)
        {
            currentIndex++;
            if (currentIndex >= targetsPoints.Length)
            {
                currentIndex = 0;
            }
            agent.destination = targetsPoints[currentIndex].position;
        }
        Debug.Log(currentIndex);
    }
}
