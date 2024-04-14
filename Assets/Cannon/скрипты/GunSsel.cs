using UnityEngine;
using UnityEngine.UI;


public class GunSelection : MonoBehaviour
{
    public Button[] buttons; // Массив кнопок для выбора пушки
    public GameObject[] guns; // Массив пушек
    public GameObject emptyObject; // Пустой объект, который можно настроить через инспектор
    private GameObject selectedGun; // Выбранная пушка
    private GameObject currentGun; // Текущая пушка на сцене
    public ScoreManager scoreManager; // Менеджер очков

    void Start()
    {
        // Назначаем каждой кнопке функцию выбора пушки
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Локальный индекс для замыкания
            buttons[i].onClick.AddListener(() => SelectGun(index));
        }
    }

    void Update()
    {
        // Проверяем, был ли клик мышью
        if (Input.GetMouseButtonDown(0) && selectedGun != null)
        {
            // Создаем луч от позиции камеры в направлении указателя мыши
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Проверяем, столкнулся ли луч с коллайдером
            if (Physics.Raycast(ray, out hit))
            {
                // Если столкнулся, проверяем, является ли объект пустым
                if (hit.collider.gameObject == emptyObject)
                {
                    // Если да, и у нас достаточно очков, и нет текущей пушки на сцене, устанавливаем пушку на место пустого объекта
                    if (scoreManager.CanAfford(1) && currentGun == null)
                    {
                        currentGun = Instantiate(selectedGun, emptyObject.transform.position, Quaternion.identity);
                        scoreManager.SpendScore(1); // Вычитаем стоимость пушки из очков
                    }
                }
            }
        }
    }

    // Функция выбора пушки
    void SelectGun(int index)
    {
        selectedGun = guns[index];
    }
}
