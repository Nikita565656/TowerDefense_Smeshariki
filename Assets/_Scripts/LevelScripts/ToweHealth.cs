using UnityEngine;

public class MainTower : MonoBehaviour
{
    public int health = 100;

    void OnTriggerEnter(Collider other)
    {
        // ���� ���� ������ � ��������� ������� �����
        if (other.gameObject.CompareTag("Enemy"))
        {
            // ��������� �������� ������� �����
            health -= 30;

            // ���� �������� ������� ����� ��������� ����
            if (health <= 0)
            {
                // ������� � ������� ��������� "Game over"
                Debug.Log("Game over");
            }
        }
    }
}
