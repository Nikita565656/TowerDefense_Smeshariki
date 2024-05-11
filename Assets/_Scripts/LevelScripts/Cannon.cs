using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float fireRate = 1f;
    public int damage = 30;
    public float raycastRange = 100f;
    private GameObject target;
    private float nextFireTime;

    void Update()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 1f, transform.forward, out hit, raycastRange))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                target = hit.collider.gameObject;
                transform.LookAt(target.transform);
            }
        }

        if (target != null && Time.time > nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
       
    }
}