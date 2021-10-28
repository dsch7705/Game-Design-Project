using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRamp : MonoBehaviour
{
    public float boostStrength;
    Transform forceDirection;


    private void Start()
    {
        forceDirection = GetComponentInChildren<Transform>();
        Debug.Log(forceDirection.tag + "!");
    }

    void RampBoost(Rigidbody rb)
    {
        //rb.AddForce();
    }
}
