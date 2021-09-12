using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponClass
{

    public string _name;
    /// <summary>
    /// 0 for single shot, 1 for semi auto
    /// </summary>
    public int _fireMode;
    /// <summary>
    /// bullets per second
    /// </summary>
    public float _fireRate;

    public WeaponClass(string name, int fireMode, float fireRate)
    {
        _name = name;
        _fireMode = (int)Mathf.Clamp(fireMode, 0.0f, 1.0f);
        _fireRate = fireRate;

    }
}
