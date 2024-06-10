using UnityEngine;
using UnityEngine.UI;
using TMPro;


public interface IInteraction
{
    //����� �޼���
    string message { get; }

    //message�� ����� ������Ʈ�� �ʼ������� �־���Ѵ�
    TextMeshProUGUI text { get; }

    //�޼��� �ѱ�,����
    void OnMessage();

    void CloseMessage();

    void Interaction(); //��ȣ�ۿ� �Լ�
}
