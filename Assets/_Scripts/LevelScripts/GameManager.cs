using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Button yourButton; // кнопка на канвасе
    public int enemyKillCount = 5; // количество врагов, которых нужно убить для переключения сцены
    private int currentKillCount = 0;

    private void Start()
    {
        yourButton.onClick.AddListener(SwitchScene);
        Enemy.OnEnemyKilled += EnemyKilled;

        // Сделайте кнопку невидимой в начале
        yourButton.gameObject.SetActive(false);
    }

    private void EnemyKilled()
    {
        currentKillCount++;

        // Если достигнуто необходимое количество убийств, сделайте кнопку видимой
        if (currentKillCount >= enemyKillCount)
        {
            yourButton.gameObject.SetActive(true);
        }
    }

    private void SwitchScene()
    {
        // Если текущая сцена - "2 level", переключите на "3 level". В противном случае переключите на "2 level".
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
