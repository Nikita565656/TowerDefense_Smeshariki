using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Button yourButton; // ������ �� �������
    public int enemyKillCount = 5; // ���������� ������, ������� ����� ����� ��� ������������ �����
    private int currentKillCount = 0;

    private void Start()
    {
        yourButton.onClick.AddListener(SwitchScene);
        Enemy.OnEnemyKilled += EnemyKilled;

        // �������� ������ ��������� � ������
        yourButton.gameObject.SetActive(false);
    }

    private void EnemyKilled()
    {
        currentKillCount++;

        // ���� ���������� ����������� ���������� �������, �������� ������ �������
        if (currentKillCount >= enemyKillCount)
        {
            yourButton.gameObject.SetActive(true);
        }
    }

    private void SwitchScene()
    {
        // ���� ������� ����� - "2 level", ����������� �� "3 level". � ��������� ������ ����������� �� "2 level".
        if (SceneManager.GetActiveScene().name == "2 level")
        {
            SceneManager.LoadScene("3 level");
        }
        else
        {
            SceneManager.LoadScene("2 level");
        }
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyKilled -= EnemyKilled;
    }
}
