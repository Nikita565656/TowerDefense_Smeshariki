using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damagePoints = 100;
    public bool isAlive = true; // Добавлено новое значение

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            isAlive = false; // Устанавливаем isAlive в false, когда враг уничтожен
            ScoreManager.instance.AddScore(damagePoints);
            Destroy(gameObject);
        }
    }
}
