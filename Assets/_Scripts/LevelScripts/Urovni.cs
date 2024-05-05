using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public GameObject canvas; // ������ Canvas
    public Button levelButton1; // ������ ������ 1
    public Button levelButton2; // ������ ������ 2
    public Button levelButton3; // ������ ������ 3

    private bool areButtonsVisible = false; // ��������� ��������� ������

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            areButtonsVisible = !areButtonsVisible; // ������������ ��������� ���������
            levelButton1.gameObject.SetActive(areButtonsVisible); // ��������� ��������� ������ 1
            levelButton2.gameObject.SetActive(areButtonsVisible); // ��������� ��������� ������ 2
            levelButton3.gameObject.SetActive(areButtonsVisible); // ��������� ��������� ������ 3
        }
    }

    public void OnLevelButton1Clicked()
    {
        // ����� �� ������ �������� ��� ��� �������� �� ������� 1
        SceneManager.LoadScene("1 level");
    }

    public void OnLevelButton2Clicked()
    {
        // ����� �� ������ �������� ��� ��� �������� �� ������� 2
        SceneManager.LoadScene("2 level");
    }

    public void OnLevelButton3Clicked()
    {
        // ����� �� ������ �������� ��� ��� �������� �� ������� 3
        SceneManager.LoadScene("3 level");
    }
}
