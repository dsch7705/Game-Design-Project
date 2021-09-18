using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents current;
    private void Awake()
    {
        current = this;
    }

    public event Action OnSwitchWeapon;
    public void SwitchWeapon()
    {
        if (OnSwitchWeapon != null)
        {
            OnSwitchWeapon();
        }
    }

    public event Action OnWeaponManagerReady;
    public void WeaponManagerReady()
    {
        if (OnWeaponManagerReady != null)
        {
            OnWeaponManagerReady();
        }
    }

    public event Action OnEnemyKilled;
    public void EnemyKilled()
    {
        if (OnEnemyKilled != null)
        {
            OnEnemyKilled();
        }
        else
        {
            Debug.Log("No subscribers to OnEnemyKilled");
        }
    }

    public event Action OnPlayerKillsChanged;
    public void PlayerKillsChanged()
    {
        if (OnPlayerKillsChanged != null)
        {
            OnPlayerKillsChanged();
        }
    }

    public event Action OnSpawnEnemy;
    public void SpawnEnemy()
    {
        if (OnSpawnEnemy != null)
        {
            OnSpawnEnemy();
        }
    }

    public event Action OnAudioManagerReady;
    public void AudioManagerReady()
    {
        if (OnAudioManagerReady != null)
        {
            OnAudioManagerReady();
        }
    }
}
