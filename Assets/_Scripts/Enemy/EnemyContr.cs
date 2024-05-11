using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyContr : MonoBehaviour
{
    [SerializeField] private GameObject targetsPoints;
    private NavMeshAgent agent;
    private int currentIndex = 0;


    public EnemyData enemyData;
    public ScoreManager scoreManager;

    private float currentSpeed;
    private float currentHp;
    private float currentDamage;
    private int Price;
    private int Scoree;

    void Start()
    {
        currentSpeed = enemyData.EnemySpeed;
        currentHp = enemyData.EnemyHp;
        currentDamage = enemyData.Enemydamage;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = currentSpeed;
        targetsPoints = GameObject.FindGameObjectWithTag("MainCastle");
        agent.SetDestination(targetsPoints.transform.position);
        Price = enemyData.MyPrice;
        Scoree = scoreManager.score;
    }

    
    void Update()
    {
        if (currentHp <= 0)
        {
            Destroy(gameObject);
            Price += Scoree;

        }

    }
  
        
}
