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
    private GameObject lastEnemy;
    Transform enemyHolder;

    // Wave Vars
    public int wave = 1;
    public int enemiesInWave;
    public int enemiesAtOnce;
    public float enemyMultiplier = 1.5f;
    public float enemyGrowthRate = 0.25f;
    public bool waveActive;
    public int waveKills = 0;

    private void Start()
    {
        current = this;

        //GameEvents.current.OnEnemyKilled += WaveManager;
        GameEvents.current.OnSpawnEnemy += SpawnEnemy;

        ObjectPool objectPool = ObjectPoolManager.current.CreatePool("Enemy", enemyPrefab, count, true);
        enemyPool = objectPool; //ObjectPoolManager.current.CreatePool("Enemies", enemyPrefab, 10);

        enemyHolder = new GameObject("Enemies").transform;
        StartWave(wave);
    }

    public void DestroyEnemy(GameObject enemy)
    {
        enemyPool.Destroy(enemy, 0);
        lastEnemy = enemy;
        //StartWave(2);

        AudioManager.current.PlayRandomClip(GameAssets.current.enemyDeathClips);
    }

    public void StartEnemySpawn()
    {
        StartCoroutine(WaitForSpawn());
    }

    public void SpawnEnemy()
    {

        if (waveKills + enemiesAtOnce <= enemiesInWave)
        {
            Enemy enemy = /*GameObject.Instantiate(enemyPrefab, new Vector3(0f, 10f, 0f), Quaternion.identity, enemyHolder).GetComponent<Enemy>();*/   enemyPool.Instantiate(new Vector3(Mathf.Cos(Random.Range(0, Mathf.PI * 2)) * 68f, 10f, 0f), Quaternion.identity, lastEnemy).GetComponent<Enemy>();
        }
        else if (waveKills == enemiesInWave)
        {
            wave++;
            StartWave(wave);
        }
        else
        {
            Debug.Log("No more enemies to spawn");
        }
    }

    public void SpawnFirstEnemy()
    {
        Enemy enemy = enemyPool.Instantiate(new Vector3(0f, 10f, 0f), Quaternion.identity, 0).GetComponent<Enemy>();
    }

    public void StartWave(int waveNumber)
    {

        enemyPool.DisableAll();

        enemyMultiplier += enemyGrowthRate;

        wave = waveNumber;
        enemiesInWave = (int)(wave * enemyMultiplier);
        enemiesAtOnce = 1 + (int)(enemiesInWave / 2.0f);

        // Debug.Log("New wave started with " + enemiesInWave + " enemies, " + enemiesAtOnce + " at a time.");
        waveActive = true;

        waveKills = 0;

        for (int i = 0; i < enemiesAtOnce; i++)
        {
            SpawnFirstEnemy();
            //Debug.Log("spawning enemy " + i);
        }

        //WaveManager();
    }

    private void Update()
    {
        //WaveManager();
    }

    //public void WaveManager()
    //{
    //    Debug.Log("Starting wave with " + enemiesInWave + " enemies.");
    //    if (enemyPool.GetActiveCount() < enemiesAtOnce && Player.current.kills + enemiesAtOnce <= enemiesInWave)
    //    {
    //        SpawnFirstEnemy();
    //    }
    //    else if (Player.current.kills >= enemiesInWave)
    //    {
    //        wave++;
    //        StartWave(wave);
    //    }
    //}

    IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(1);
        SpawnEnemy();
    }
}

