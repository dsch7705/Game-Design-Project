using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public WeaponClass currentWeaponClass;
    
    public List<WeaponClass> weapons = new List<WeaponClass>();
    void Start()
    {
        weapons.Add(new WeaponClass("Pistol", WeaponClass.FireMode.semi, 10f));
        currentWeaponClass = weapons[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (weapons.Count + 1 > weapons.IndexOf(currentWeaponClass))
    }
}
