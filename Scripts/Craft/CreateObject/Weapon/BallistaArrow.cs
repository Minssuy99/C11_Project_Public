using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaArrow : Projectile
{
    Rigidbody rigidbody;
    Vector3 direction;

    public float disableTime;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = direction;
    }

    public override void Fire()
    {
        //direction = -transform.right * data.speed;
        direction = transform.forward * data.speed;
        Invoke("Disable", disableTime);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
        direction = Vector3.zero;
    }

    //private void OnDisable()
    //{
    //}
}
