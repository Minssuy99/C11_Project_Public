using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public float attackDistance;

    public float attackrate;
    public float lastAttackTime;
    private GameObject player;

    public float followDistance;
    public float speed;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        bool chk = Vector3.Distance(transform.position, player.transform.position) < attackDistance;

        if (Time.time - lastAttackTime > attackrate && chk)
        {
            Debug.Log("����");
            lastAttackTime = Time.time;
        }

        bool follow = Vector3.Distance(transform.position, player.transform.position) < followDistance;

        if (follow)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
