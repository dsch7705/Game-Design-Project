using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour
{
    private TMP_Text textObject;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnPlayerDamaged += UpdateHealthDisplay;
        textObject = GetComponent<TMP_Text>();
    }

    void UpdateHealthDisplay()
    {
        textObject.text = "Health: " + Player.current.GetPlayerHealth().ToString();
    }
}
