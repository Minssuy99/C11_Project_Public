using UnityEngine;


//�ڿ� ����
public enum ResourceType
{
    Wood,
    Stone,
    Gold,
}

//������ �ʿ� ���� �� ����
[System.Serializable]
public class RequirResource
{
    public ResourceType type;
    public int amount;
}

[CreateAssetMenu(fileName = "CreateBase", menuName = "CreateObject/CreateBase",order = 0)]
public class CreateObjectSO : ScriptableObject
{
    [Header("������Ʈ")]
    public string objectName;
    public string content;

    public Sprite icon;

    [Tooltip("���� �ʿ��ڿ�")]
    public RequirResource[] resources; //������ �� �ʿ��� �ڿ�

    [Tooltip("���ӿ�����Ʈ�� ������")]
    public GameObject prefab;
}
