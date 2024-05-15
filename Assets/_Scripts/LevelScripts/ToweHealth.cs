using UnityEngine;
using UnityEngine.UI;

public class MainTower : MonoBehaviour
{
    public int health = 100;
    public EnemyData enemyData;
    public GameObject LoseTable;
    private int EnemyDammage;

    void Start()
    {
        EnemyDammage = enemyData.Enemydamage;
        LoseTable.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            
            health -= EnemyDammage;

            
            Destroy(other.gameObject);

           
            if (health <= 0)
            {
                Time.timeScale = 0f;

                LoseTable.SetActive(true); 
            }
        }
    }
}
