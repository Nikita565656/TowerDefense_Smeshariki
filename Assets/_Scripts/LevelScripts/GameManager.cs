using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemiesToKill = 10; // Количество врагов, которых нужно убить для победы
    private int enemiesKilled = 0; // Количество убитых врагов
    public Text winText; // Текстовый элемент для отображения сообщения о победе
    public Button nextLevelButton; // Кнопка для перехода на следующий уровень

    void Start()
    {
        winText.gameObject.SetActive(false); // Скрываем текст о победе в начале игры
        nextLevelButton.gameObject.SetActive(false); // Скрываем кнопку перехода на следующий уровень в начале игры
    }

    public void EnemyKilled()
    {
        enemiesKilled++; // Увеличиваем количество убитых врагов

        if (enemiesKilled >= enemiesToKill)
        {
            Win(); // Если убито достаточное количество врагов, объявляем победу
        }
    }

    void Win()
    {
        winText.gameObject.SetActive(true); // Показываем текст о победе
        nextLevelButton.gameObject.SetActive(true); // Показываем кнопку перехода на следующий уровень
    }

    public void GoToNextLevel()
    {
        // Загружаем следующий уровень 
        SceneManager.LoadScene("2 уровень");
    }
}
