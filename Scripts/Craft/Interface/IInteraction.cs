using UnityEngine;
using UnityEngine.UI;
using TMPro;


public interface IInteraction
{
    //출력할 메세지
    string message { get; }

    //message를 출력할 컴포넌트가 필수적으로 있어야한다
    TextMeshProUGUI text { get; }

    //메세지 켜기,끄기
    void OnMessage();

    void CloseMessage();

    void Interaction(); //상호작용 함수
}
