using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    // Singleton
    public static EnemyManager current;

    // Enemy Vars
    public GameObject enemyPrefab;
    public ObjectPool enemyPool;
    public int count;

    // Wave Vars
    public int wave = 1;
    public int enemiesInWave;
    public int enemiesAtOnce;
    public float enemyMultiplier = 1.5f;
    public bool waveActive;

    private void Start()
    {
        current = this;

        GameEvents.current.OnEnemyKilled += WaveManager;
        GameEvents.current.OnSpawnEnemy += SpawnEnemy;

        ObjectPool objectPool = ObjectPoolManager.current.CreatePool("Enemy", enemyPrefab, count, true);
        enemyPool = objectPool; //ObjectPoolManager.current.CreatePool("Enemies", enemyPrefab, 10);

        StartWave(4);
    }

    public void DestroyEnemy(GameObject enemy)
    {
        enemyPool.Destroy(enemy);
        //StartWave(2);

        AudioManager.current.PlayRandomClip(GameAssets.current.enemyDeathClips);
    }

    public void SpawnEnemy()
    {
        Enemy enemy = enemyPool.Instantiate(new Vector3(0f, 10f, 0f), Quaternion.identity, enemyPool.GetLastIndex()).GetComponent<Enemy>();
    }

    public void StartWave(int waveNumber)
    {
        enemyPool.DisableAll();

        wave = waveNumber;
        enemiesInWave = (int)(wave * enemyMultiplier);
        enemiesAtOnce = (int)(enemiesInWave / 2.0f);

        waveActive = true;
        WaveManager();
    }

    private void Update()
    {
        WaveManager();
    }

    public void WaveManager()
    {
        Debug.Log("Starting wave with " + enemiesInWave + " enemies.");
        if (enemyPool.GetActiveCount() < enemiesAtOnce && Player.current.kills + enemiesAtOnce < enemiesInWave)
        {

            SpawnEnemy();
        }
    }
}
