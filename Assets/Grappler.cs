using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    public SpringJoint spring;
    [SerializeField] private float springForce;

    public static Grappler current;

    void Start()
    {
        current = this;
    }

    public void ShootGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            ConnectGrapple(hit);
        }
    }

    void ConnectGrapple(RaycastHit hit)
    {
        spring.anchor = hit.point;
        spring.spring = springForce;
    }
}
