using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayInput : MonoBehaviour
{
    public float xMove, zMove, mouseX, mouseY;
    public int switchWeapon;
    public bool leftClick, leftClickHold;

    void Update()
    {
        xMove         = Input.GetAxisRaw("Horizontal");
        zMove         = Input.GetAxisRaw("Vertical");

        mouseX        = Input.GetAxis("Mouse X") + Input.GetAxis("ControllerHorizontal");
        mouseY        = Input.GetAxis("Mouse Y") + Input.GetAxis("ControllerVertical");

        switchWeapon  = (int)Input.GetAxis("Switch Weapon");

        leftClick     = Input.GetMouseButtonDown(0);
        leftClickHold = Input.GetMouseButton(0);
    }

    private void OnDisable()
    {
        xMove         = 0.0f;
        zMove         = 0.0f;

        mouseX        = 0.0f;
        mouseY        = 0.0f;

        switchWeapon  = 0;

        leftClick     = false;
        leftClickHold = false;
    }
}
