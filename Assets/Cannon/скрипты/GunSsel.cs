using UnityEngine;
using UnityEngine.UI;


public class GunSelection : MonoBehaviour
{
    public Button[] buttons; // ������ ������ ��� ������ �����
    public GameObject[] guns; // ������ �����
    public GameObject emptyObject; // ������ ������, ������� ����� ��������� ����� ���������
    private GameObject selectedGun; // ��������� �����
    private GameObject currentGun; // ������� ����� �� �����
    public ScoreManager scoreManager; // �������� �����

    void Start()
    {
        // ��������� ������ ������ ������� ������ �����
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // ��������� ������ ��� ���������
            buttons[i].onClick.AddListener(() => SelectGun(index));
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
                // ���� ����������, ���������, �������� �� ������ ������
                if (hit.collider.gameObject == emptyObject)
                {
                    // ���� ��, � � ��� ���������� �����, � ��� ������� ����� �� �����, ������������� ����� �� ����� ������� �������
                    if (scoreManager.CanAfford(1) && currentGun == null)
                    {
                        currentGun = Instantiate(selectedGun, emptyObject.transform.position, Quaternion.identity);
                        scoreManager.SpendScore(1); // �������� ��������� ����� �� �����
                    }
                }
            }
        }
    }

    // ������� ������ �����
    void SelectGun(int index)
    {
        selectedGun = guns[index];
    }
}
