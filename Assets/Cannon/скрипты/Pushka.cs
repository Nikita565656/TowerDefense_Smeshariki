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
            // ������������ ����� � �����
            transform.LookAt(targetEnemy.transform);

            if (Time.time >= nextFireTime)
            {
                Fire();
                nextFireTime = Time.time + fireRate;
            }

            // ��������� ������ ��������
            trackingTimer -= Time.deltaTime;
        }
        else
        {
            // ���� ������ �������� ����� ��� ���� ����������, ���������� ����
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
        // ���� ���� ������ � ��������� �����
        if (other.gameObject.CompareTag("Enemy"))
        {
            // ������ ����� � �������� ���� � ������������� ������ ��������
            targetEnemy = other.gameObject;
            trackingTimer = trackingTime;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // ���� ���� ������� �� ���������� �����
        if (other.gameObject.CompareTag("Enemy"))
        {
            // ���������� ����
            targetEnemy = null;
        }
    }
}