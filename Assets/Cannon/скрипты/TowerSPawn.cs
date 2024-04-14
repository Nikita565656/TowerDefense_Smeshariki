using UnityEngine;
using UnityEngine.UI;

public class SpawnGun : MonoBehaviour
{
    public Button[] buttons; // ������ ������ ��� ������ �����
    public GameObject[] gunPrefabs; // ������ �������� �����
    public GameObject[] spawnPoints; // ������ ����� ������
    private GameObject selectedGun; // ��������� �����
    private bool[] hasSpawned; // ������ ��� ������������, ���� �� �� ������ ����� ������ ������� �����
    public int cost = 300;

    void Start()
    {
        // ��������� ������ ������ ������� ������ �����
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // ��������� ������ ��� ���������
            buttons[i].onClick.AddListener(() => SelectGun(index));
        }

        // �������������� ������ hasSpawned
        hasSpawned = new bool[spawnPoints.Length];
    }

    void Update()
    {
        // ���������, ��� �� ���� �����
        if (Input.GetMouseButtonDown(0) && selectedGun != null)
        {
            // ������� ��� �� ������� ������ � ����������� ��������� ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ���������, ���������� �� ��� � �����������
            if (Physics.Raycast(ray, out hit))
            {
                // ���� ����������, ���������, �������� �� ������ ������ ������
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    if (hit.collider.gameObject == spawnPoints[i] && !hasSpawned[i] && ScoreManager.instance.CanAfford(cost))
                    {
                        // ���� ��, � �� ���� ����� ������ ��� ��� �����, � � ��� ���������� �����, ������������� ����� �� ��� ����� ������
                        Instantiate(selectedGun, spawnPoints[i].transform.position, Quaternion.identity);
                        ScoreManager.instance.SpendScore(cost); // �������� ��������� ����� �� �����
                        hasSpawned[i] = true; // ��������, ��� �� ���� ����� ������ ������ ���� �����
                        break; // ������� �� �����, ��� ��� �� ��� ���������� ���� ����
                    }
                }
            }
        }
    }

    // ������� ������ �����
    void SelectGun(int index)
    {
        if (index >= 0 && index < gunPrefabs.Length)
        {
            selectedGun = gunPrefabs[index];
        }
    }
}
