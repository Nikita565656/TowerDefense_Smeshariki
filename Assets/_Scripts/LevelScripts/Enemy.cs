using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damagePoints = 100;
    public bool isAlive = true; 

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            isAlive = false; 
            ScoreManager.instance.AddScore(damagePoints);
            Destroy(gameObject);
        }
    }
}
