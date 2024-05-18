using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Button yourButton; // кнопка на канвасе
    public Text yourText; // текст на канвасе
    public int enemyKillCount = 5; // количество врагов, которых нужно убить для переключения сцены
    private int currentKillCount = 0;

    private void Start()
    {
        yourButton.onClick.AddListener(SwitchScene);
        Enemy.OnEnemyKilled += EnemyKilled;

        // Сделайте кнопку и текст невидимыми в начале
        yourButton.gameObject.SetActive(false);
        yourText.gameObject.SetActive(false);
    }

    private void EnemyKilled()
    {
        currentKillCount++;

        // Если достигнуто необходимое количество убийств, сделайте кнопку и текст видимыми
        if (currentKillCount >= enemyKillCount)
        {
            Time.timeScale = 0;
            yourButton.gameObject.SetActive(true);
            yourText.gameObject.SetActive(true);
            
        }
    }

    private void SwitchScene()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 1)
        {

            SceneManager.LoadScene(2);
           
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2)
        {

        SceneManager.LoadScene(0);
        }
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyKilled -= EnemyKilled;
    }
}
