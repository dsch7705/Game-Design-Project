using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRamp : MonoBehaviour
{
    public float boostStrength;
    Vector3 forceDirection;


    private void Start()
    {
        forceDirection = GetComponentInChildren<SpeedRampForceVector>().GetDirection();
    }

    public void RampBoost(Rigidbody rb)
    {
        rb.AddForce(forceDirection * boostStrength, ForceMode.Impulse);
    }
}
