using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player current;
    public int kills = 0;
    public LayerMask enemyLayer;
    private int health = 25;

    private void Start()
    {
        current = this;

        GameEvents.current.OnEnemyKilled += PlayVoiceLine;
        GameEvents.current.OnEnemyKilled += KilledEnemy;
        GameEvents.current.PlayerDamaged();
    }

    private void OnCollisionEnter(Collision collision)
    {
        int layer = collision.gameObject.layer;
        if (enemyLayer == 1 << layer)
        {
            Damage(10);
        }
    }

    public float GetPlayerX()
    {
        return transform.position.x;
    }

    public float GetPlayerY()
    {
        return transform.position.y;
    }

    public int GetPlayerHealth()
    {
        return health;
    }

    public string GetPlayerHealthString()
    {
        Debug.Log(health.ToString());
        return health.ToString();
    }

    public void Damage(int damage)
    {
        health -= damage;
        GameEvents.current.PlayerDamaged();
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        Debug.Log("Player took damage");
    }

    private void Die()
    {
        GameEvents.current.PlayerDied();
        GetComponent<PlayerMovement>().enabled = false;
        GetComponentInChildren<PlayerShoot>().enabled = false;
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
        EnemyManager.current.waveKills++;
        Debug.Log(EnemyManager.current.waveKills);
        GameEvents.current.PlayerKillsChanged();
    }

    public int GetKillCount()
    {
        return kills;
    }
}
