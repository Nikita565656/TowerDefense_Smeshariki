using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] public EnemyData enemyData;
    public float damageAmount ;
    public void Start()
    {
        damageAmount = enemyData.Enemydamage;
    }
    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Tower"))
        {
            
            TowerDied towerHealth = other.GetComponent<TowerDied>();

            
            if (towerHealth != null)
            {
                
                towerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
