using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float accelerationSpeed = 5;
    public float maxSpeed = 10;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Gather keyboard input
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        // Store keyboard input in a Vector3, normalize and tweak speed
        Vector3 move = new Vector3(xMove, 0, zMove).normalized * accelerationSpeed * Time.deltaTime;
        rb.velocity += move;

        // Check if player let off keyboard, decelerate if so
        if (move.x == 0 && rb.velocity.x != 0)
        {
            rb.velocity += new Vector3(-rb.velocity.x / 2 * accelerationSpeed * Time.deltaTime, 0, 0);
        }

        if (move.z == 0 && rb.velocity.z != 0)
        {
            rb.velocity += new Vector3(0, 0, -rb.velocity.z / 2 * accelerationSpeed * Time.deltaTime);
        }

        // Clamp velocity to maxSpeed variable
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;

        }

        Debug.Log(rb.velocity);
    }
}
