using UnityEngine;
using UnityEngine.UI;

public class SpawnGun : MonoBehaviour
{
    public Button[] buttons; // Массив кнопок для выбора пушки
    public GameObject[] gunPrefabs; // Массив префабов пушек
    public GameObject[] gunParticles; // Массив префабов партиклов пушек
    public int[] gunPrices; // Массив цен пушек
    public GameObject[] spawnPoints; // Массив точек спавна
    private GameObject selectedGun; // Выбранная пушка
    private int selectedGunPrice; // Цена выбранной пушки
    private bool[] hasSpawned; // Массив для отслеживания, была ли на каждой точке спавна создана пушка
    private GameObject[][] gunParticlesInstances; // Массив для хранения экземпляров партиклов

    void Start()
    {
        // Назначаем каждой кнопке функцию выбора пушки
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Локальный индекс для замыкания
            buttons[i].onClick.AddListener(() => SelectGun(index));
        }

        // Инициализируем массивы hasSpawned и gunParticlesInstances
        hasSpawned = new bool[spawnPoints.Length];
        gunParticlesInstances = new GameObject[spawnPoints.Length][];
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
                // Если столкнулся, проверяем, является ли объект точкой спавна
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    if (hit.collider.gameObject == spawnPoints[i] && !hasSpawned[i] && ScoreManager.instance.CanAfford(selectedGunPrice))
                    {
                        // Если да, и на этой точке спавна еще нет пушки, и у нас достаточно очков, устанавливаем пушку на эту точку спавна
                        Instantiate(selectedGun, spawnPoints[i].transform.position, Quaternion.identity);
                        ScoreManager.instance.SpendScore(selectedGunPrice); // Вычитаем стоимость пушки из очков
                        hasSpawned[i] = true; // Отмечаем, что на этой точке спавна теперь есть пушка

                        // Удаляем текущие партиклы с этой точки спавна
                        if (gunParticlesInstances[i] != null)
                        {
                            foreach (GameObject particle in gunParticlesInstances[i])
                            {
                                Destroy(particle);
                            }
                            gunParticlesInstances[i] = null;
                        }
                        break; // Выходим из цикла, так как мы уже обработали этот клик
                    }
                }
            }
        }
    }

    // Функция выбора пушки
    void SelectGun(int index)
    {
        if (index >= 0 && index < gunPrefabs.Length)
        {
            selectedGun = gunPrefabs[index];
            selectedGunPrice = gunPrices[index]; // Запоминаем цену выбранной пушки

            // Удаляем текущие партиклы со всех точек спавна
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (gunParticlesInstances[i] != null)
                {
                    foreach (GameObject particle in gunParticlesInstances[i])
                    {
                        Destroy(particle);
                    }
                    gunParticlesInstances[i] = null;
                }

                // Создаем новые партиклы на точках спавна, где еще нет пушки
                if (!hasSpawned[i])
                {
                    gunParticlesInstances[i] = new GameObject[gunParticles.Length];
                    for (int j = 0; j < gunParticles.Length; j++)
                    {
                        gunParticlesInstances[i][j] = Instantiate(gunParticles[j], spawnPoints[i].transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
