using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Defense", menuName = "CreateObject/Construct/Defense", order = 0)]
public class DefenseConstructSO : CreateObjectSO
{
    [Header("���ǹ�")]

    [Tooltip("���� ���ݱ��� ���ð�")]
    public float attackRate;

    [Tooltip("��Ÿ�")]
    public float attackDistance;

    //�߻� ������ ���� ����
    //[Tooltip("����ü")]
    //public GameObject projectilePrefab;
}
