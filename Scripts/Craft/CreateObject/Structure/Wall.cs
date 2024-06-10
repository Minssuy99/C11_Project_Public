using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : CreateObject
{
    float durability;

    // Start is called before the first frame update
    void Start()
    {
        durability = (objectData as WallConstructSO).durability;
    }

    //IDamagAble 인터페이스 필요, 플레이어에서 만들까봐 안만듬
}
