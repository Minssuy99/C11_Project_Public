using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "CreateObject/Item/Resource", order = 0)]
public class ItemSO : CreateObjectSO
{
    [Header("æ∆¿Ã≈€")]
    public bool stackable;
    public int amount;
    public int maxStack;
}
