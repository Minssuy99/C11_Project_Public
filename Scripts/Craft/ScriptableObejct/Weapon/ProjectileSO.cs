using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Defense", menuName = "CreateObject/Weapon/Projectile", order = 0)]
public class ProjectileSO : ItemSO
{
    [Header("����ü")]
    public float speed;

    public float damage;
}
