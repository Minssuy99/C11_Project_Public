using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    Direct, //����
    Highangle //���
}

[RequireComponent(typeof(SphereCollider),typeof(Animator))]
public class DefenseConstruct : CreateObject
{
    public AttackType type;

    public Transform launchTransform;
    DefenseConstructSO data;

    Animator animator;
    SphereCollider collider;
    public GameObject target; //���� ���� Ÿ��
    public Projectile projectile;

    float lastAttackTime;
    bool isReady = true; //����غ�

    // Start is called before the first frame update
    protected void Start()
    {
        data = objectData as DefenseConstructSO;
        animator = GetComponent<Animator>();
        collider = GetComponent<SphereCollider>();

        collider.radius = data.attackDistance;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (!isReady && Time.time - lastAttackTime > data.attackRate)
        {
            lastAttackTime = Time.time;
            projectile.transform.position = launchTransform.position; //����ü ��ġ
            projectile.gameObject.SetActive(true);
            isReady = true;

        }

        if(isReady && IsLook())
        {
            Aim();
            Attack();
        }
    }

    protected void Attack()
    {
        animator.SetTrigger("Attack");
        isReady = false;
    }

    public virtual void Fire()
    {
        if(type == AttackType.Highangle)
        {
            CatapultProjectile catapultProjectile = projectile as CatapultProjectile;
            catapultProjectile.targetPos = target.transform.position;
            catapultProjectile.transform.parent = null;
        }

        projectile.Fire();
    }

    protected void OnTriggerEnter(Collider other)
    {
        //Ÿ���� ���ų� ��Ȱ��ȭ ���¶�� Ÿ���� ��ü
        if (target == null || !target.activeInHierarchy) target = other.gameObject;
    }

    protected void Aim()
    {
        Vector3 dir = (target.transform.position - transform.position).normalized;
        transform.eulerAngles = new Vector3(0f, Mathf.Atan2(dir.x,dir.z) * Mathf.Rad2Deg,0f);
    }

    protected bool IsLook()
    {
        return target != null && target.activeInHierarchy;
    }

    //���� �̸�����
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if(data != null)
            Gizmos.DrawWireSphere(transform.position,(objectData as DefenseConstructSO).attackDistance);
    }
}
