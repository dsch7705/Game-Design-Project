using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponDisplay : MonoBehaviour
{

    public TMP_Text textObject;

    // Start is called before the first frame update
    void Start()
    {
        textObject = GetComponent<TMP_Text>();

        GameEvents.current.OnWeaponManagerReady += UpdateWeaponInfo;
        GameEvents.current.OnSwitchWeapon += UpdateWeaponInfo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateWeaponInfo()
    {
        textObject.text = WeaponManager.current.GetWeaponClassName();
    }
}
