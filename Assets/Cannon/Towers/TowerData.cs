using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "ScriptableObjects/TowerData", order = 2)]
public class TowerData : ScriptableObject
{
    [SerializeField] private string TowerName;
    [SerializeField] private float TowerSpeedShoot;
    [SerializeField] private int Damage;


    public int Towerdamage => Damage;
    public float towerspeedshoot => TowerSpeedShoot;

    public string Towername => TowerName;


}
