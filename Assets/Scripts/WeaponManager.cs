using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    // Singleton
    public static WeaponManager current;

    // Current weapon class, stored in tuple
    public (WeaponClass, int) currentWeaponClass;
    [SerializeField] private int _currentWeaponClass;
    
    // List of all weapons in player's inventory
    public List<WeaponClass> weapons = new List<WeaponClass>();

    void Start()
    {
        current = this;

        weapons.Add(new WeaponClass("Pistol", 2.0f, 0, 2.0f));
        weapons.Add(new WeaponClass("Assault Rifle", 10.0f, 1, 10.0f));

        currentWeaponClass.Item1 = weapons[0];
        currentWeaponClass.Item2 = 0;

        GameEvents.current.WeaponManagerReady();
    }

    // Update is called once per frame
    void Update()
    {
        // shitty fix, reassess input system as a whole
        if ((int)Input.GetAxis("Switch Weapon") != 0)
        { SwitchWeapon((int)Input.GetAxis("Switch Weapon")); }
    }

    // Updates weapon choice via scrollwheel
    public void SwitchWeapon(int change)
    {
        if (currentWeaponClass.Item2 + change >= weapons.Count || 
            currentWeaponClass.Item2 + change < 0)
        {
            return;
        }

        _currentWeaponClass = currentWeaponClass.Item2 += change;
        currentWeaponClass.Item1 = weapons[currentWeaponClass.Item2];
        GameEvents.current.SwitchWeapon();
    }

    public string GetWeaponClassName()
    {
        return currentWeaponClass.Item1._name;
    }

    // TERRIBLE FIX
    public int boolToInt(bool b)
    {
        if (b == true) { return 1; }
        return -1;
    }
}
