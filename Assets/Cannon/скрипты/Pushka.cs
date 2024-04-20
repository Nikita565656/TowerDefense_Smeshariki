using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 1.0f;
    private float nextFireTime;
    private GameObject targetEnemy;
    public float trackingTime = 3.0f;
    private float trackingTimer;

    void Update()
    {
        if (targetEnemy != null)
        {
            // Проверяем, жив ли враг
            Enemy enemyScript = targetEnemy.GetComponent<Enemy>();
            if (enemyScript != null && enemyScript.isAlive)
            {
                // Поворачиваем пушку к врагу
                transform.LookAt(targetEnemy.transform);

                if (Time.time >= nextFireTime)
                {
                    Fire();
                    nextFireTime = Time.time + fireRate;
                }
            }
            else
            {
                // Если враг уничтожен, сбрасываем цель
                targetEnemy = null;
            }
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.target = targetEnemy;
    }

    void OnTriggerEnter(Collider other)
    {
        // Если враг входит в коллайдер пушки и у пушки еще нет цели
        if (other.gameObject.CompareTag("Enemy") && targetEnemy == null)
        {
            // Задаем врага в качестве цели
            targetEnemy = other.gameObject;
        }
    }
}
