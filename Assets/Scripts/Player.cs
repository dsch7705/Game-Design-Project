using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player current;
    public int kills = 0;

    private void Start()
    {
        current = this;

        GameEvents.current.OnEnemyKilled += PlayVoiceLine;
        GameEvents.current.OnEnemyKilled += KilledEnemy;
    }

    public float GetPlayerX()
    {
        return transform.position.x;
    }

    public float GetPlayerY()
    {
        return transform.position.y;
    }

    public void PlayVoiceLine()
    {
        //int rand = Random.Range(1, 50);
        //Debug.Log(rand);
        //if (rand == 1)
        //{
        //    AudioManager.current.PlayRandomClip(GameAssets.current.voiceLineClips);
        //}
    }

    public void KilledEnemy()
    {
        kills++;
        GameEvents.current.PlayerKillsChanged();
    }

    public int GetKillCount()
    {
        return kills;
    }
}
