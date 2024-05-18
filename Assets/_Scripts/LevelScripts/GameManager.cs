using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject PanelWin;
    public int enemyKillCount = 5; 
    private int currentKillCount = 0;

    private void Start()
    {
        Enemy.OnEnemyKilled += EnemyKilled;

        PanelWin.gameObject.SetActive(false);
    }

    private void EnemyKilled()
    {
        currentKillCount++;

        if (currentKillCount >= enemyKillCount)
        {
            Time.timeScale = 0;
            PanelWin.gameObject.SetActive(true); 
        }
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyKilled -= EnemyKilled;
    }
}
