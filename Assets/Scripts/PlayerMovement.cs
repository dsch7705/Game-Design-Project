using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Input
    private GameplayInput gameInput;

    // Player movement vars
    Rigidbody rb;
    public float accelerationSpeed = 5.0f;
    public float maxSpeed = 10.0f;
    public float velocityMultiplier = 1.0f;

    // Player jump vars
    public Collider groundCheck;
    public bool isGrounded;
    public float jumpForce = 10;
    Vector3 jumpVector;
    
    // Camera vars
    public Camera cam;
    public Transform hRotationHelper;
    public Transform vRotationHelper;
    public float camTiltAmount;
    public float camTiltSmooth;
    Vector3 camTiltVelocity = new Vector3(0.0f, 0.0f, 0.0f);

    public float camSmooth = 0.3f;
    float yVelocity = 0.0f;
    float xVelocity = 0.0f;
    float xRotOld;
    float xRotation = 0.0f;

    void Start()
    {
        gameInput = GetComponent<GameplayInput>();

        rb = GetComponent<Rigidbody>();

        hRotationHelper.localRotation = transform.localRotation;
        vRotationHelper.localRotation = cam.transform.localRotation;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        #region Player

        // Keyboard input
        float xMove = gameInput.xMove;
        float zMove = gameInput.zMove;

        // Store keyboard input in a Vector3, normalize and tweak speed
        Vector3 move = (transform.right * xMove + transform.forward * zMove).normalized * accelerationSpeed * Time.deltaTime;

        // Exponentially increase movement speed, apply movement
        velocityMultiplier = Mathf.Clamp(rb.velocity.magnitude / 8, 1, 50);

        rb.velocity += move * velocityMultiplier;

        // Check if player let off keyboard, decelerate if so
        if (move.x == 0 && rb.velocity.x != 0)
        {
            rb.velocity += new Vector3(-rb.velocity.x / 10 * accelerationSpeed * Time.deltaTime, 0, 0);
        }

        if (move.z == 0 && rb.velocity.z != 0)
        {
            rb.velocity += new Vector3(0, 0, -rb.velocity.z / 10 * accelerationSpeed * Time.deltaTime);
        }

        // Clamp velocity to maxSpeed variable
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        #endregion

        #region Camera

        // Gather mouse input for camera
        float mouseX = gameInput.mouseX;
        float mouseY = gameInput.mouseY;


        // Calculate up and down cam rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // Rotate helper for smooth cam rotation
        hRotationHelper.Rotate(Vector3.up * mouseX, Space.Self);
        vRotationHelper.localRotation = Quaternion.Euler((Vector3.right * xRotation) + new Vector3(gameInput.zMove * camTiltAmount, 0.0f, -gameInput.xMove * camTiltAmount));

        // Apply cam rotation
        Vector3 camTilt = (transform.right * gameInput.xMove + transform.forward * gameInput.zMove).normalized * accelerationSpeed * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(Mathf.SmoothDampAngle(transform.eulerAngles.x, hRotationHelper.eulerAngles.x, ref camTiltVelocity.x, camTiltSmooth), Mathf.SmoothDampAngle(transform.eulerAngles.y, hRotationHelper.eulerAngles.y, ref yVelocity, camSmooth), -gameInput.xMove);
        cam.transform.localRotation = Quaternion.Euler(Mathf.SmoothDampAngle(cam.transform.eulerAngles.x, vRotationHelper.eulerAngles.x, ref xVelocity, camSmooth), 0, 0);
        #endregion
    }

    void ScreenShift()
    {
        transform.rotation = Quaternion.Euler(0.01f, 0.0f, 0.01f);
        //transform.rotation = Quaternion.Euler(rb.velocity.x, transform.rotation.y, rb.velocity.z);
    }

}
