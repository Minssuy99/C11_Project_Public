using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapConstructSO : CreateObjectSO
{
    [Header("함정")]
    public float damage;

    [Tooltip("지속데미지 여부")]
    public bool persistant;

    [Tooltip("다음 데미지까지의 시간")]
    public float damageRate;
}
