using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 1.0f;
    private float nextFireTime;
    private GameObject targetEnemy;
    private float trackingTime = 5.0f;
    private float trackingTimer;

    void Update()
    {
        if (targetEnemy != null && trackingTimer > 0)
        {
            // Поворачиваем пушку к врагу
            transform.LookAt(targetEnemy.transform);

            if (Time.time >= nextFireTime)
            {
                Fire();
                nextFireTime = Time.time + fireRate;
            }

            // Уменьшаем таймер слежения
            trackingTimer -= Time.deltaTime;
        }
        else
        {
            // Если таймер слежения истек или цель уничтожена, сбрасываем цель
            targetEnemy = null;
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
        // Если враг входит в коллайдер пушки
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Задаем врага в качестве цели и устанавливаем таймер слежения
            targetEnemy = other.gameObject;
            trackingTimer = trackingTime;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Если враг выходит из коллайдера пушки
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Сбрасываем цель
            targetEnemy = null;
        }
    }
}