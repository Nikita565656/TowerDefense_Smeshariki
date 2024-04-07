using UnityEngine;

public class MainTower : MonoBehaviour
{
    public int health = 100;

    void OnTriggerEnter(Collider other)
    {
        // Если враг входит в коллайдер главной башни
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Уменьшаем здоровье главной башни
            health -= 30;

            // Если здоровье главной башни достигает нуля
            if (health <= 0)
            {
                // Выводим в консоль сообщение "Game over"
                Debug.Log("Game over");
            }
        }
    }
}
