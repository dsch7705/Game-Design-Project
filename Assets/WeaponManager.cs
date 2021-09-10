using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public (WeaponClass, int) currentWeaponClass;
    private int _currentWeaponClass;
    
    public List<WeaponClass> weapons = new List<WeaponClass>();
    void Start()
    {
        weapons.Add(new WeaponClass("Pistol", WeaponClass.FireMode.semi, 10f));
        currentWeaponClass.Item1 = weapons[0];
        currentWeaponClass.Item2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Switch Weapon") != 0 && weapons.Count + 1 > weapons.IndexOf(currentWeaponClass.Item1))
        {
            currentWeaponClass.Item1 = weapons[weapons.IndexOf(currentWeaponClass.Item1) + 1];
            currentWeaponClass.Item2, _currentWeaponClass = weapons.IndexOf(currentWeaponClass.Item1);
        }
    }
}
