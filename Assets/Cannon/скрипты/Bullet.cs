using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    public int damage = 30;
    public float speed = 10.0f;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
        {
            Enemy enemyScript = target.GetComponent<Enemy>();
            enemyScript.TakeDamage(damage);
            if (enemyScript.health <= 0)
            {
                Destroy(target);
            }
            Destroy(gameObject);
        }
    }
}
