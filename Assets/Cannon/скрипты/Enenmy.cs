using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damagePoints = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            ScoreManager.instance.AddScore(damagePoints);
            Destroy(gameObject);
        }
    }
}