using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CraftingBox : InteractionObject
{
    public GameObject craftFrame;
   
    //��ȣ�ۿ�
    public override void Interaction()
    {
        craftFrame.SetActive(true);
    }
}
