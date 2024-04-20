using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyDataVitya : ScriptableObject
{
    [SerializeField] private string enemyName;
    [SerializeField] private int health;
    [SerializeField] private float Speed;
    [SerializeField] private int Damage;

    public int Enemydamage => Damage;
    public float EnemySpeed => Speed;

    public string Enemyname => enemyName;

    public int EnemyHp => health;
}
