using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayInput : MonoBehaviour
{
    public float xMove, zMove, mouseX, mouseY;
    public int switchWeapon;
    public bool leftClick, leftClickHold, rightClick, rightClickHold, jump;

    void Update()
    {
        // Movement
        xMove          = Input.GetAxisRaw("Horizontal");
        zMove          = Input.GetAxisRaw("Vertical");

        jump           = Input.GetKeyDown(KeyCode.Space);

        // Camera
        mouseX         = Input.GetAxis("Mouse X") + Input.GetAxis("ControllerHorizontal");
        mouseY         = Input.GetAxis("Mouse Y") + Input.GetAxis("ControllerVertical");

        // Weapons
        switchWeapon   = (int)Input.GetAxis("Switch Weapon");

        // Mouse input
        leftClick      = Input.GetMouseButtonDown(0);
        leftClickHold  = Input.GetMouseButton(0);

        rightClick     = Input.GetMouseButtonDown(1);
        rightClickHold = Input.GetMouseButton(1);
    }

    private void OnDisable()
    {
        xMove          = 0.0f;
        zMove          = 0.0f;

        jump           = false;

        mouseX         = 0.0f;
        mouseY         = 0.0f;

        switchWeapon   = 0;

        leftClick      = false;
        leftClickHold  = false;
    }
}
