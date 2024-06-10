using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class InteractionObject : MonoBehaviour,IInteraction
{
    public TextMeshProUGUI text;

    public string message => "[E] Ű�� ���� ��ȣ�ۿ�";
    TextMeshProUGUI IInteraction.text => text;

    public float interactionDistance;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        GetComponent<SphereCollider>().radius = interactionDistance;
        text.text = message;
    }
    //���� �����ֱ�
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }

    //�����ȿ� ��������
    protected virtual void OnTriggerEnter(Collider other)
    {
        //�浹 ������ �ٲ���ҵ�
        if (other.tag == "Player")
        {
            OnMessage();

            ref IInteraction interaction = ref other.GetComponent<PlayerController>().interactionObject;
            if (interaction == null) interaction = this;
        }
    }

    //���������� ��������
    protected virtual void OnTriggerExit(Collider other)
    {
        //�浹 ������ �ٲ���ҵ�
        if (other.tag == "Player")
        {
            CloseMessage();

            ref IInteraction interaction = ref other.GetComponent<PlayerController>().interactionObject;
            if (interaction == this) interaction = null;
        }
    }

    //�޼��� ���ֱ�
    public virtual void OnMessage()
    {
        text.transform.parent.gameObject.SetActive(true);
    }

    //�޼��� ���ֱ�
    public virtual void CloseMessage()
    {
        text.transform.parent.gameObject.SetActive(false);
    }

    public virtual void Interaction() { }
}
