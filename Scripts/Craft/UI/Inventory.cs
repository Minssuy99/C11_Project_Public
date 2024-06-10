using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum ButtonType
{
    Equip,
    UnEquip,
    Throw,
}

public class Inventory : MonoBehaviour
{
    public int size;
    public GameObject slotPrefab;

    ItemSlot[] slots;
    int index;

    public Button[] buttons;
    public Transform slotTransfrom;

    List<int> emptySlotIndex;
    List<int> UseSlotIndex;

    public int[] resourceAmount; //나무 돌 돈


    private void Start()
    {
        resourceAmount = new int[sizeof(ResourceType)];
        slots = new ItemSlot[size];
        emptySlotIndex = new List<int>(size);
        UseSlotIndex = new List<int>(size);

        for (int i = 0; i < size; i++)
        {
            GameObject go =  Instantiate(slotPrefab, slotTransfrom);
            ItemSlot slot = go.GetComponent<ItemSlot>();
            slots[i] = slot;
            slot.GetComponent<ItemSlot>().index = i;
            slot.inventory = this;

            emptySlotIndex.Add(i);
        }
        gameObject.SetActive(false);
    }

    public void OnClickSlot(int index)
    {
        if (slots[index].item == null)
        {
            foreach(Button btn in buttons)
                btn.interactable = false;

            return;
        }


        //if() 장착중이면 
        // buttons[(int)ButtonType.UnEquip].interactable = true;
        // buttons[(int)ButtonType.Equip].interactable = false;
        //else 장착중이지 않으면
        // buttons[(int)ButtonType.UnEquip].interactable = fasle;
        // buttons[(int)ButtonType.Equip].interactable = true;


        buttons[(int)ButtonType.Throw].interactable = true;

        this.index = index;
    }

    public void Equip()
    {
        //플레이어 필요

        //if() 플레이어의 장착유무 확인
        //UnEquip(); 장착아이템 해제
        //장착해제 후 해당 아이템 착용
        //items[index]
    }

    public void UnEquip()
    {
        //아이템 장착 방식이 정해지고 난뒤에 만들듯
    }

    public void Throw()
    {
        //플레이어 포지션받아와서 버려야할듯
    }

    public void GetItem(Item item)
    {
        if(item.TryGetComponent(out Resource resource))
            resourceAmount[(int)resource.type] += item.data.amount;

        //사용중인 칸에 중첩이 가능한지 확인
        if (UseSlotIndex.Count > 0)
        {
            foreach(int i in UseSlotIndex)
            {
                ItemSO data = slots[i].item.data;

                bool nameCheck = (data.name == item.data.name);
                bool amountCheck = (data.amount < data.maxStack);

                if (nameCheck  && data.stackable && amountCheck)
                {
                    slots[i].StackItem(data.amount);
                    return;
                }
            }
        }

        //사용중인 칸이 없거나 중첩이 불가능하면 작동
        int index = emptySlotIndex[0];
        slots[index].SetItem(item);

        UseSlotIndex.Add(index);
        emptySlotIndex.Remove(index);
    }
}
