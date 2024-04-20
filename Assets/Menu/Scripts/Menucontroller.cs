using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menucontroller : MonoBehaviour 
{
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused) {
                Resum();
            }
            else
            {
                Pause();
            }
        }
       
    }
    public void Resum()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadSceneMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadSceneGame()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void LoadSceneLevels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void LoadSceneIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Quit()
    {
       Application.Quit();
    }
    public void RestartLevel()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeScene);
    }

}
