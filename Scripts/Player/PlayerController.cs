using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ������ ����
    [Header("Moverment")]
    public float speed; // �̵� �ӵ�
    float hAxis; // ��,�� �̵�
    float vAxis; // ��,�� �̵�

    [Header("Attack")]
    bool fDown; // ���� Ű�Է�
    float fireDelay; // ���� ������
    bool isFireReady; // ���� �غ�   

    [Header("Weapon")]
    public GameObject[] weapons;

    public PlayerCondition condition;

    Vector3 moveVec;

    Animator anim;

    Weapon equipWeapon;
    
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        condition = GetComponentInChildren<PlayerCondition>();
        equipWeapon = weapons[0].GetComponent<Weapon>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // ȭ����� ���콺 Ŀ�� �����
    }

    void Update()
    {
        GetInput();
        Move();
        Turn();
        Attack();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        fDown = Input.GetButtonDown("Fire1");

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Swap((CharacterManager.Instance.character - 1) * 2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Swap((CharacterManager.Instance.character -1) * 2 + 1);
        }
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);   
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Swap(int weaponCount)
    {
        weapons[(weaponCount + 1) % 2 + (CharacterManager.Instance.character - 1) * 2].SetActive(false);
        equipWeapon = weapons[weaponCount].GetComponent<Weapon>();
        weapons[weaponCount].SetActive(true);
        
    }

    void Attack()
    {
        if (equipWeapon == null)
            return;

        fireDelay += Time.deltaTime;
        isFireReady = equipWeapon.rate < fireDelay;

        if(fDown && isFireReady)
        {
            //equipWeapon.Use();
            anim.SetTrigger("doSwing");
            fireDelay = 0;
        }
    }
}
