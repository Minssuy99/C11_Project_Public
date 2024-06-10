using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Outline))]
public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Outline outline;

    protected virtual void Start()
    {
        outline = GetComponent<Outline>();
    }

    //interfaceŬ������ virtual�� �����Լ� �����ϸ� �ڽĵ� ��밡��
    //���콺�� �ش� ���ӿ�����Ʈ�� ����Ű��������
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        outline.enabled = true;
    }

    //���콺�� �ش� ���ӿ�����Ʈ�� ����Ű��������
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        outline.enabled = false;
    }
}
