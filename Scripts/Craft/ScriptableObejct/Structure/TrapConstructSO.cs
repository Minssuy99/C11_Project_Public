using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapConstructSO : CreateObjectSO
{
    [Header("����")]
    public float damage;

    [Tooltip("���ӵ����� ����")]
    public bool persistant;

    [Tooltip("���� ������������ �ð�")]
    public float damageRate;
}
