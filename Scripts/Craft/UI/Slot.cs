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

    //interface클래스를 virtual로 가상함수 선언하면 자식도 사용가능
    //마우스가 해당 게임오브젝트를 가르키고있을때
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        outline.enabled = true;
    }

    //마우스가 해당 게임오브젝트를 가르키지않을때
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        outline.enabled = false;
    }
}
