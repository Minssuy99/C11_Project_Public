using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Defense", menuName = "CreateObject/Construct/Defense", order = 0)]
public class DefenseConstructSO : CreateObjectSO
{
    [Header("방어건물")]

    [Tooltip("다음 공격까지 대기시간")]
    public float attackRate;

    [Tooltip("사거리")]
    public float attackDistance;

    //발사 연출을 위해 제외
    //[Tooltip("투사체")]
    //public GameObject projectilePrefab;
}
