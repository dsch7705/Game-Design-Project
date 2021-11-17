using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhysicsMonitor : MonoBehaviour
{
    public Rigidbody Rbody;
    public TMP_Text gText;

    float lastV = 0;

    private void Start()
    {
        gText = GetComponent<TMP_Text>();

        StartCoroutine(PollGForce());
    }

    private void FixedUpdate()
    {

        
    }

    void GetGForce(Rigidbody rb, float lastV)
    {
        float gforce = Mathf.Abs(Mathf.Round((lastV - rb.velocity.magnitude) / Time.deltaTime * 1000f) / 1000f) / 9.81f;
        SetGForceDisplay(gforce);
    }

    void SetGForceDisplay(float gforce)
    {
        gText.text = "GForce: " + gforce;
    }

    IEnumerator PollGForce()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            GetGForce(Rbody, lastV);
            lastV = Rbody.velocity.magnitude;
        }
    }

}
