using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemiesToKill = 10; // ���������� ������, ������� ����� ����� ��� ������
    private int enemiesKilled = 0; // ���������� ������ ������
    public Text winText; // ��������� ������� ��� ����������� ��������� � ������
    public Button nextLevelButton; // ������ ��� �������� �� ��������� �������

    void Start()
    {
        winText.gameObject.SetActive(false); // �������� ����� � ������ � ������ ����
        nextLevelButton.gameObject.SetActive(false); // �������� ������ �������� �� ��������� ������� � ������ ����
    }

    public void EnemyKilled()
    {
        enemiesKilled++; // ����������� ���������� ������ ������

        if (enemiesKilled >= enemiesToKill)
        {
            Win(); // ���� ����� ����������� ���������� ������, ��������� ������
        }
    }

    void Win()
    {
        winText.gameObject.SetActive(true); // ���������� ����� � ������
        nextLevelButton.gameObject.SetActive(true); // ���������� ������ �������� �� ��������� �������
    }

    public void GoToNextLevel()
    {
        // ��������� ��������� ������� 
        SceneManager.LoadScene("2 �������");
    }
}
