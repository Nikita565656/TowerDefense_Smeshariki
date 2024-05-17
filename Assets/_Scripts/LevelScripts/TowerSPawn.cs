using UnityEngine;
using UnityEngine.UI;

public class SpawnGun : MonoBehaviour
{
    public Button[] buttons; // ������ ������ ��� ������ �����
    public GameObject[] gunPrefabs; // ������ �������� �����
    public GameObject[] gunParticles; // ������ �������� ��������� �����
    public int[] gunPrices; // ������ ��� �����
    public GameObject[] spawnPoints; // ������ ����� ������
    private GameObject selectedGun; // ��������� �����
    private int selectedGunPrice; // ���� ��������� �����
    private bool[] hasSpawned; // ������ ��� ������������, ���� �� �� ������ ����� ������ ������� �����
    private GameObject[][] gunParticlesInstances; // ������ ��� �������� ����������� ���������

    void Start()
    {
        // ��������� ������ ������ ������� ������ �����
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // ��������� ������ ��� ���������
            buttons[i].onClick.AddListener(() => SelectGun(index));
        }

        // �������������� ������� hasSpawned � gunParticlesInstances
        hasSpawned = new bool[spawnPoints.Length];
        gunParticlesInstances = new GameObject[spawnPoints.Length][];

        // ������� �������� �� ���� ������ ������
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            CreateParticles(i);
        }
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
                    if (hit.collider.gameObject == spawnPoints[i] && !hasSpawned[i] && ScoreManager.instance.CanAfford(selectedGunPrice))
                    {
                        // ���� ��, � �� ���� ����� ������ ��� ��� �����, � � ��� ���������� �����, ������������� ����� �� ��� ����� ������
                        Instantiate(selectedGun, spawnPoints[i].transform.position, Quaternion.identity);
                        ScoreManager.instance.SpendScore(selectedGunPrice); // �������� ��������� ����� �� �����
                        hasSpawned[i] = true; // ��������, ��� �� ���� ����� ������ ������ ���� �����

                        // ������� ������� �������� � ���� ����� ������
                        DestroyParticles(i);
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
            selectedGunPrice = gunPrices[index]; // ���������� ���� ��������� �����

            // ������� �������� �� ���� ������ ������, ��� ��� ��� �����
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (!hasSpawned[i])
                {
                    CreateParticles(i);
                }
            }
        }
    }

    // ������� ��� �������� ��������� �� ����� ������
    void CreateParticles(int spawnPointIndex)
    {
        // ������� ������� �������� � ���� ����� ������
        DestroyParticles(spawnPointIndex);

        // ������� ����� �������� �� ���� ����� ������
        gunParticlesInstances[spawnPointIndex] = new GameObject[gunParticles.Length];
        for (int j = 0; j < gunParticles.Length; j++)
        {
            gunParticlesInstances[spawnPointIndex][j] = Instantiate(gunParticles[j], spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
        }
    }

    // ������� ��� �������� ��������� � ����� ������
    void DestroyParticles(int spawnPointIndex)
    {
        if (gunParticlesInstances[spawnPointIndex] != null)
        {
            foreach (GameObject particle in gunParticlesInstances[spawnPointIndex])
            {
                Destroy(particle);
            }
            gunParticlesInstances[spawnPointIndex] = null;
        }
    }
}
