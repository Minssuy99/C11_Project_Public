using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : Slot
{
    public Item item;
    public int index;
    public TextMeshProUGUI text;
    public Inventory inventory;
    public Image icon;


    private void Start()
    {
        base.Start();
        icon = GetComponent<Image>();
    }

    public void OnClick()
    {
        inventory.OnClickSlot(index);
    }

    public void SetItem(Item item)
    {
        this.item = item;
        icon.sprite = item.data.icon;
    }

    public void StackItem(int amount)
    {
        item.data.amount += amount;
    }
}
