using UnityEngine;
using UnityEngine.SceneManagement;


public class Menucontroller : MonoBehaviour 
{
    
    
    public void LoadSceneMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadSceneGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadSceneSettings()
        {
            SceneManager.LoadScene("Settings");
        }
    
    public void LoadSceneLevels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void Quit()
    {
       Application.Quit();
    }
}
