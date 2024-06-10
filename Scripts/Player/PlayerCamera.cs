using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private GameObject target;
    public Vector3 offset;

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        transform.position = target.GetComponent<Transform>().position + offset;
    }
}
