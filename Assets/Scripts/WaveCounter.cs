using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveCounter : MonoBehaviour
{
    private TMP_Text textObject;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnWaveCompleted += UpdateWaveText;
        GameEvents.current.OnEnemyManagerReady += UpdateWaveText;

        textObject = GetComponent<TMP_Text>();
        Debug.Log("wave counter started");
    }

    void UpdateWaveText()
    {
        textObject.text = "Wave: " + EnemyManager.current.wave;
    }
}
