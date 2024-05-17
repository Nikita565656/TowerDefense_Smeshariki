using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public EnemyData enemyData;
    public int damagePoints = 100;
    public bool isAlive = true;

    public static event System.Action OnEnemyKilled;

    private void Start()
    {
        health = enemyData.EnemyHp;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            isAlive = false;
            ScoreManager.instance.AddScore(damagePoints);
            Destroy(gameObject);

            OnEnemyKilled?.Invoke();
        }
    }
}
