using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    Direct, //직사
    Highangle //곡사
}

[RequireComponent(typeof(SphereCollider),typeof(Animator))]
public class DefenseConstruct : CreateObject
{
    public AttackType type;

    public Transform launchTransform;
    DefenseConstructSO data;

    Animator animator;
    SphereCollider collider;
    public GameObject target; //현재 공격 타겟
    public Projectile projectile;

    float lastAttackTime;
    bool isReady = true; //사격준비

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
            projectile.transform.position = launchTransform.position; //투사체 배치
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
        //타겟이 없거나 비활성화 상태라면 타겟을 교체
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

    //범위 미리보기
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if(data != null)
            Gizmos.DrawWireSphere(transform.position,(objectData as DefenseConstructSO).attackDistance);
    }
}
