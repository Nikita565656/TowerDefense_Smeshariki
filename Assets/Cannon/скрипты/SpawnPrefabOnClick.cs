using UnityEngine;

public class SpawnPrefabOnClick : MonoBehaviour
{
    public GameObject prefab; // Префаб, который нужно спавнить
    private GameObject spawnedObject; // Спавненный объект
    public int score = 300; // Текущий счет, установлен в 300 на старте
    public int spawnCost = 300; // Стоимость спавна турели
    public int killReward = 100; // Награда за убийство врага

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Проверка нажатия левой кнопки мыши
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // Проверка попадания луча в коллайдер
            {
                if (hit.transform == this.transform) // Проверка, что попадание было именно в этот объект
                {
                    if (score >= spawnCost) // Проверка, достаточно ли очков для спавна турели
                    {
                        if (spawnedObject != null) // Удаление предыдущего объекта, если он существует
                        {
                            Destroy(spawnedObject);
                        }
                        spawnedObject = Instantiate(prefab, transform.position, Quaternion.identity); // Спавн нового объекта
                        score -= spawnCost; // Вычитание стоимости спавна из текущего счета
                    }
                }
            }
        }
    }

    public void EnemyKilled()
    {
        score += killReward; // Добавление награды к текущему счету при убийстве врага
    }
}
