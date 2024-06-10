using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ������ ����
    [Header("Moverment")]
    public float speed; // �̵� �ӵ�
    float hAxis; // ��,�� �̵�
    float vAxis; // ��,�� �̵�
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
        Cursor.lockState = CursorLockMode.Locked; // ȭ����� ���콺 Ŀ�� �����
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
