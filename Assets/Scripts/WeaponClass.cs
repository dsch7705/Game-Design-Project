using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponClass
{

    public string _name;
    public float _damage;
    /// <summary>
    /// 0 for single shot, 1 for full auto
    /// </summary>
    public int _fireMode;
    /// <summary>
    /// bullets per second
    /// </summary>
    public float _fireRate;
    /// <summary>
    /// 0 for normal, 1 for explosive, 2 for shotgun
    /// </summary>
    public int _ammoType;

    public WeaponClass(string name, float damage, int fireMode, float fireRate, int ammoType)
    {
        _name = name;
        _damage = damage;
        _fireMode = (int)Mathf.Clamp(fireMode, 0.0f, 1.0f);
        _fireRate = fireRate;
        _ammoType = ammoType;

    }
}
