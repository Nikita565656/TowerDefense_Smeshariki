using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 30;
    public float speed = 10.0f;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(damage);
        }
    }
}
