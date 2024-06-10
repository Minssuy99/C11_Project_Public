using UnityEngine;


//자원 유형
public enum ResourceType
{
    Wood,
    Stone,
    Gold,
}

//데이터 필요 종류 및 수량
[System.Serializable]
public class RequirResource
{
    public ResourceType type;
    public int amount;
}

[CreateAssetMenu(fileName = "CreateBase", menuName = "CreateObject/CreateBase",order = 0)]
public class CreateObjectSO : ScriptableObject
{
    [Header("오브젝트")]
    public string objectName;
    public string content;

    public Sprite icon;

    [Tooltip("생산 필요자원")]
    public RequirResource[] resources; //생성할 때 필요한 자원

    [Tooltip("게임오브젝트의 프리펩")]
    public GameObject prefab;
}
