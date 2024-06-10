using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class InteractionObject : MonoBehaviour,IInteraction
{
    public TextMeshProUGUI text;

    public string message => "[E] 키를 눌러 상호작용";
    TextMeshProUGUI IInteraction.text => text;

    public float interactionDistance;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        GetComponent<SphereCollider>().radius = interactionDistance;
        text.text = message;
    }
    //범위 보여주기
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }

    //범위안에 들어왔을때
    protected virtual void OnTriggerEnter(Collider other)
    {
        //충돌 조건은 바꿔야할듯
        if (other.tag == "Player")
        {
            OnMessage();

            ref IInteraction interaction = ref other.GetComponent<PlayerController>().interactionObject;
            if (interaction == null) interaction = this;
        }
    }

    //범위밖으로 나갔을때
    protected virtual void OnTriggerExit(Collider other)
    {
        //충돌 조건은 바꿔야할듯
        if (other.tag == "Player")
        {
            CloseMessage();

            ref IInteraction interaction = ref other.GetComponent<PlayerController>().interactionObject;
            if (interaction == this) interaction = null;
        }
    }

    //메세지 켜주기
    public virtual void OnMessage()
    {
        text.transform.parent.gameObject.SetActive(true);
    }

    //메세지 꺼주기
    public virtual void CloseMessage()
    {
        text.transform.parent.gameObject.SetActive(false);
    }

    public virtual void Interaction() { }
}
