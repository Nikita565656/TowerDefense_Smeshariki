using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public GameObject canvas; // Объект Canvas
    public Button levelButton1; // Кнопка уровня 1
    public Button levelButton2; // Кнопка уровня 2
    public Button levelButton3; // Кнопка уровня 3

    private bool areButtonsVisible = false; // Состояние видимости кнопок

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            areButtonsVisible = !areButtonsVisible; // Переключение состояния видимости
            levelButton1.gameObject.SetActive(areButtonsVisible); // Установка видимости кнопки 1
            levelButton2.gameObject.SetActive(areButtonsVisible); // Установка видимости кнопки 2
            levelButton3.gameObject.SetActive(areButtonsVisible); // Установка видимости кнопки 3
        }
    }

    public void OnLevelButton1Clicked()
    {
        // Здесь вы можете добавить код для перехода на уровень 1
        SceneManager.LoadScene("1 level");
    }

    public void OnLevelButton2Clicked()
    {
        // Здесь вы можете добавить код для перехода на уровень 2
        SceneManager.LoadScene("2 level");
    }

    public void OnLevelButton3Clicked()
    {
        // Здесь вы можете добавить код для перехода на уровень 3
        SceneManager.LoadScene("3 level");
    }
}
