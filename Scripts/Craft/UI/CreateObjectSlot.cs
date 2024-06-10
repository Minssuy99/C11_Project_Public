using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CreateObjectSlot : Slot//,IPointerEnterHandler,IPointerExitHandler
{
    [Header("출력부분")]
    public Image objectIcon;
    public TextMeshProUGUI objectName;
    public TextMeshProUGUI objectContent;
    private Outline outline;

    [Header("오브젝트 데이터")]
    public CreateObjectSO data;

    [Header("자원")]
    public Transform resources;
    public ResourcesSlot slotPrefab;

    public ObjectBuild build;

    //제작 가능 불가능 확인
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
        //데이터 보여주기
        objectIcon.sprite = data.icon;
        objectName.text = data.objectName;
        objectContent.text = data.content;

        for (int i = 0; i < data.resources.Length; i++)
        {
            //게임오브젝트 복사
            ResourcesSlot slot = Instantiate(slotPrefab, resources);
            RequirResource resource = data.resources[i];

            //아이콘 이미지 설정
            int index = (int)resource.type;
            slot.icon.sprite = slot.iconImages[index];

            //텍스트 설정
            slot.amountText.text = resource.amount.ToString();
        }
    }


    //자원 소모 필요
    public void OnBuildConstruct(GameObject root)
    {
        root.SetActive(false);
        build.gameObject.SetActive(true);
        build.ChangeObject(data.prefab,data);
    }
    
    //아이템만들기
    public void OnCreateItem(GameObject root)
    {
        root.SetActive(false);

        Inventory inventory = CharacterManager.Instance._player.controller.inventory;

        foreach (RequirResource resource in data.resources)
        {
            int index = (int)resource.type;
            inventory.resourceAmount[index] -= resource.amount;
        }

        //아이템을 생성해서 인벤토리로 전달해야함,자원도 소모해야함
        //Instantiate(data.prefab);
        //Player.instance.inventory.GetItem(Instantiate(data as Item));
    }
}
