using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyData enemyData; // ������ �� ��� ScriptableObject
    private int currentHealth; // ������� �������� �����

    void Start()
    {
        currentHealth = enemyData.health; // ������������� �������� �����
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ���������� �������� �����
        if (currentHealth < 0)
        {
            currentHealth = 0; // ���������, ��� �������� �� ������ ���� 0
        }
    }
}
