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

    //IDamagAble �������̽� �ʿ�, �÷��̾�� ������ �ȸ���
}
