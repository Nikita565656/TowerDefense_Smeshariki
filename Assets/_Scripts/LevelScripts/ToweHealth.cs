using UnityEngine;
using UnityEngine.UI;

public class MainTower : MonoBehaviour
{
    public int health = 100;
    public Text gameOverText; // �������� � ���������� ������ �� ��������� ������ �� ����� �������

    void Start()
    {
        gameOverText.enabled = false; // �������� ����� "Game over" � ������ ����
    }

    void OnTriggerEnter(Collider other)
    {
        // ���� ���� ������ � ��������� ������� �����
        if (other.gameObject.CompareTag("Enemy"))
        {
            // �������� ��������� Enemy �����
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            // ��������� �������� ������� ����� �� ���������� ����� ����� �����
            health -= enemy.damagePoints;

            // ������� ����� ����� ��������� �����
            Destroy(other.gameObject);

            // ���� �������� ������� ����� ��������� ����
            if (health <= 0)
            {
                // ������� �� ������� ��������� "Game over"
                gameOverText.enabled = true;
            }
        }
    }
}
