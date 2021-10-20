using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel : MonoBehaviour
{

    public int weaponID;

    void Start()
    {
        GameEvents.current.OnWeaponManagerReady += UpdateModel;
        GameEvents.current.OnSwitchWeapon += UpdateModel;
    }

    void UpdateModel()
    {
        if (WeaponManager.current.currentWeaponClass.Item1._weaponID == weaponID)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
