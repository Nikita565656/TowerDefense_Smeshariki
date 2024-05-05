using System.Collections;
using UnityEngine;

public class TowerDied : MonoBehaviour
{
    public float maxHealth = 100f; 
    private float currentHealth; 

    void Start()
    {
        currentHealth = maxHealth; 
    }

    // Функція для отримання пошкоджень
    public void TakeDamage(float amount)
    {
        
        currentHealth -= amount;

       
        if (currentHealth <= 0)
        {
            Die(); 
        }
    }

    
    void Die()
    {
        
        Destroy(gameObject); 
    }
}
