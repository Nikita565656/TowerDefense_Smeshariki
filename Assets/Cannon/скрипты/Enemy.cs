using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyData enemyData; // ссылка на ваш ScriptableObject
    private int currentHealth; // текущее здоровье врага

    void Start()
    {
        currentHealth = enemyData.health; // инициализация здоровья врага
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // уменьшение здоровья врага
        if (currentHealth < 0)
        {
            currentHealth = 0; // убедитесь, что здоровье не уходит ниже 0
        }
    }
}
