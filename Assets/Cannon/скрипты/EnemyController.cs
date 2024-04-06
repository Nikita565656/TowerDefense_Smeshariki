using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyData enemyData;
    private int currentHealth; 

    void Start()
    {
        currentHealth = enemyData.EnemyHp;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; 
        if (currentHealth < 0)
        {
            currentHealth = 0; 
        }
    }
}
