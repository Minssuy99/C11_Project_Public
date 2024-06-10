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

    public int[] resourceAmount; //���� �� ��


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


        //if() �������̸� 
        // buttons[(int)ButtonType.UnEquip].interactable = true;
        // buttons[(int)ButtonType.Equip].interactable = false;
        //else ���������� ������
        // buttons[(int)ButtonType.UnEquip].interactable = fasle;
        // buttons[(int)ButtonType.Equip].interactable = true;


        buttons[(int)ButtonType.Throw].interactable = true;

        this.index = index;
    }

    public void Equip()
    {
        //�÷��̾� �ʿ�

        //if() �÷��̾��� �������� Ȯ��
        //UnEquip(); ���������� ����
        //�������� �� �ش� ������ ����
        //items[index]
    }

    public void UnEquip()
    {
        //������ ���� ����� �������� ���ڿ� �����
    }

    public void Throw()
    {
        //�÷��̾� �����ǹ޾ƿͼ� �������ҵ�
    }

    public void GetItem(Item item)
    {
        if(item.TryGetComponent(out Resource resource))
            resourceAmount[(int)resource.type] += item.data.amount;

        //������� ĭ�� ��ø�� �������� Ȯ��
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

        //������� ĭ�� ���ų� ��ø�� �Ұ����ϸ� �۵�
        int index = emptySlotIndex[0];
        slots[index].SetItem(item);

        UseSlotIndex.Add(index);
        emptySlotIndex.Remove(index);
    }
}
