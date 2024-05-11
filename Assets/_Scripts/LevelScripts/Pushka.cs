using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 1.0f;
    private float nextFireTime;
    private GameObject _target;
    public float trackingTime = 3.0f;

    void Update()
    {
        if (_target != null)
        {
            
            Enemy enemyScript = _target.GetComponent<Enemy>();
            if (enemyScript != null && enemyScript.isAlive)
            {
                
                transform.LookAt(_target.transform);

                if (Time.time >= nextFireTime)
                {
                    Fire();
                    nextFireTime = Time.time + fireRate;
                }
            }
            else
            {
                
                _target = null;
            }
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bulletSpawnPoint.transform.LookAt(_target.transform.position);
        rb.AddForce(bulletSpawnPoint.forward * 100f, ForceMode.Impulse);

    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Enemy") && _target == null)
        {
            
            _target = other.gameObject;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && _target != null)
        {
            _target = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && _target == null)
        {
            _target = other.gameObject;
        }
    }


}
