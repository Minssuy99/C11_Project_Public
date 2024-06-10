using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//보류
public class CatapultProjectile : Projectile
{
    public Vector3 targetPos { get; set; }
    Vector3 startPos,direction;
    public AnimationCurve curve;

    float distance;

    Rigidbody rigidbody;

    float height;
    float firetime;

    bool isFire = false;

    private void FixedUpdate()
    {
        height.ToString();
        if (isFire)
        {
            //transform.position = 
            //    new Vector3
            //    (
            //        transform.position.x,
            //        height + (height * (curve.Evaluate(firetime) - 1)),
            //        transform.position.z
            //    );
            //firetime += Time.fixedDeltaTime * data.speed;
            //transform.position = new Vector3(0, height + (height * (curve.Evaluate(firetime) - 1)), 0);
            //Vector3.Distance(startPos, transform.position) / distance; //비율
            //Vector3 dir = 
            float rate = Vector3.Distance(startPos, transform.position) / distance;
            Debug.Log(rate);
            //direction.y = curve.Evaluate();
            rigidbody.velocity = direction;
        }
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public override void Fire()
    {
        startPos = transform.position;
        distance = Vector3.Distance(startPos,targetPos);

        Vector3 dir = (targetPos - startPos).normalized;
        direction = new Vector3(dir.x, 0, dir.y);

        isFire = true;
    }

    private void OnDisable()
    {
        rigidbody.velocity = direction = Vector3.zero;
        isFire = false;
    }
}
