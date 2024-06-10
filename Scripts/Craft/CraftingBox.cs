using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CraftingBox : InteractionObject
{
    public GameObject craftFrame;
   
    //상호작용
    public override void Interaction()
    {
        craftFrame.SetActive(true);
    }
}
