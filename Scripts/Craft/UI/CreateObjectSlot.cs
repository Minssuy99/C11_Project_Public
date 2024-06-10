using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CreateObjectSlot : Slot//,IPointerEnterHandler,IPointerExitHandler
{
    [Header("��ºκ�")]
    public Image objectIcon;
    public TextMeshProUGUI objectName;
    public TextMeshProUGUI objectContent;
    private Outline outline;

    [Header("������Ʈ ������")]
    public CreateObjectSO data;

    [Header("�ڿ�")]
    public Transform resources;
    public ResourcesSlot slotPrefab;

    public ObjectBuild build;

    //���� ���� �Ұ��� Ȯ��
    private void OnEnable()
    {
        Inventory inventory = CharacterManager.Instance._player.controller.inventory;

        foreach(RequirResource resource in data.resources)
        {
            int index = (int)resource.type;

            if(inventory.resourceAmount[index] < resource.amount)
            {
                GetComponent<Button>().interactable = false;
                return;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        //������ �����ֱ�
        objectIcon.sprite = data.icon;
        objectName.text = data.objectName;
        objectContent.text = data.content;

        for (int i = 0; i < data.resources.Length; i++)
        {
            //���ӿ�����Ʈ ����
            ResourcesSlot slot = Instantiate(slotPrefab, resources);
            RequirResource resource = data.resources[i];

            //������ �̹��� ����
            int index = (int)resource.type;
            slot.icon.sprite = slot.iconImages[index];

            //�ؽ�Ʈ ����
            slot.amountText.text = resource.amount.ToString();
        }
    }


    //�ڿ� �Ҹ� �ʿ�
    public void OnBuildConstruct(GameObject root)
    {
        root.SetActive(false);
        build.gameObject.SetActive(true);
        build.ChangeObject(data.prefab,data);
    }
    
    //�����۸����
    public void OnCreateItem(GameObject root)
    {
        root.SetActive(false);

        Inventory inventory = CharacterManager.Instance._player.controller.inventory;

        foreach (RequirResource resource in data.resources)
        {
            int index = (int)resource.type;
            inventory.resourceAmount[index] -= resource.amount;
        }

        //�������� �����ؼ� �κ��丮�� �����ؾ���,�ڿ��� �Ҹ��ؾ���
        //Instantiate(data.prefab);
        //Player.instance.inventory.GetItem(Instantiate(data as Item));
    }
}
