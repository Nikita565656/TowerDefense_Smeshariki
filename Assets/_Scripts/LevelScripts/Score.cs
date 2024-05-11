using UnityEngine;
using UnityEngine.UI; // Добавьте эту строку для доступа к классам UI

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; 
    public int score = 0; 
    public Text scoreText; 

    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            
            Destroy(gameObject);
        }
    }

    
    public bool CanAfford(int cost)
    {
        return score >= cost;
    }

   
    public void SpendScore(int cost)
    {
        score -= cost;
        UpdateScoreText(); 
    }

    
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText(); 
    }

    
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
