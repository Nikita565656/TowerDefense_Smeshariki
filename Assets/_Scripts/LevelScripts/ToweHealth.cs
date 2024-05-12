using UnityEngine;
using UnityEngine.UI;

public class MainTower : MonoBehaviour
{
    public int health = 100;
    public GameObject LoseTable; 

    void Start()
    {
        LoseTable.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            
            health -= enemy.damagePoints;

            
            Destroy(other.gameObject);

           
            if (health <= 0)
            {
                LoseTable.SetActive(true);
                Time.timeScale = 0f;

                
            }
        }
    }
}
