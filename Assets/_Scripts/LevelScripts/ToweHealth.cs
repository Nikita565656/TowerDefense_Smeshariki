using UnityEngine;
using UnityEngine.UI;

public class MainTower : MonoBehaviour
{
    public int health = 100;
    public Text gameOverText; // Добавьте в инспекторе ссылку на текстовый объект на вашем канвасе

    void Start()
    {
        gameOverText.enabled = false; // Скрываем текст "Game over" в начале игры
    }

    void OnTriggerEnter(Collider other)
    {
        // Если враг входит в коллайдер главной башни
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Получаем компонент Enemy врага
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            // Уменьшаем здоровье главной башни на количество очков урона врага
            health -= enemy.damagePoints;

            // Удаляем врага после нанесения урона
            Destroy(other.gameObject);

            // Если здоровье главной башни достигает нуля
            if (health <= 0)
            {
                // Выводим на канвасе сообщение "Game over"
                gameOverText.enabled = true;
            }
        }
    }
}
