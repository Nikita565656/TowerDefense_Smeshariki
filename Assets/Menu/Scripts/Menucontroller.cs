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
}
