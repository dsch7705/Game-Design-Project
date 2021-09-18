using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    private TMP_Text textObject;

    private void Start()
    {
        GameEvents.current.OnPlayerKillsChanged += UpdateKills;
        textObject = GetComponent<TMP_Text>();

        textObject.text = "Kills: 0";
    }

    private void UpdateKills()
    {
        textObject.text = "Kills: " + Player.current.GetKillCount().ToString();
    }
}
