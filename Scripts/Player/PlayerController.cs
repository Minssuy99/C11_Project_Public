using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 변수명 정리
    [Header("Moverment")]
    public float speed; // 이동 속도
    float hAxis; // 좌,우 이동
    float vAxis; // 상,하 이동
    bool wDown; 

    public PlayerCondition condition;

    Vector3 moveVec;

    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        condition = GetComponentInChildren<PlayerCondition>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 화면상의 마우스 커서 숨기기
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);

        transform.LookAt(transform.position + moveVec);
    }
}
