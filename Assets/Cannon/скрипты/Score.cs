using UnityEngine;
using UnityEngine.UI; // Добавьте эту строку для доступа к классам UI

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Статический экземпляр класса ScoreManager
    public int score = 0; // Очки игрока
    public Text scoreText; // Текстовый элемент для отображения очков

    void Awake()
    {
        // Если экземпляр еще не был установлен, устанавливаем его
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // Если экземпляр уже существует, уничтожаем этот объект
            Destroy(gameObject);
        }
    }

    // Функция проверяет, достаточно ли у игрока очков для определенной стоимости
    public bool CanAfford(int cost)
    {
        return score >= cost;
    }

    // Функция тратит определенное количество очков игрока
    public void SpendScore(int cost)
    {
        score -= cost;
        UpdateScoreText(); // Обновляем текстовый элемент после изменения очков
    }

    // Функция добавляет определенное количество очков к счету игрока
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText(); // Обновляем текстовый элемент после изменения очков
    }

    // Функция обновляет текстовый элемент с текущим количеством очков
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
