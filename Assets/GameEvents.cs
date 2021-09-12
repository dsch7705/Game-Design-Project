using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents current;
    private void Awake()
    {
        current = this;
    }

    public event Action onSwitchWeapon;
    public void SwitchWeapon()
    {
        if (onSwitchWeapon != null)
        {
            onSwitchWeapon();
        }
    }

    public event Action onWeaponManagerReady;
    public void WeaponManagerReady()
    {
        if (onWeaponManagerReady != null)
        {
            onWeaponManagerReady();
        }
    }
}
