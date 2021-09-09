using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponClass
{

    public string _name;
    public FireMode _fireMode;
    public float _fireRate;

    public enum FireMode
    {
        single,
        semi,
        full
    }

    public WeaponClass(string name, FireMode fireMode, float fireRate)
    {
        _name = name;
        _fireMode = fireMode;
        _fireRate = fireRate;

    }
}
