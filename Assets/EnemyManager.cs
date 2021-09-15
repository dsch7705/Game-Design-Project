using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    // Singleton
    public static EnemyManager current;

    public GameObject enemyPrefab;
    public ObjectPool enemyPool;

    private void Start()
    {
        current = this;

        GameEvents.current.OnSpawnEnemy += SpawnEnemy;

        ObjectPool objectPool = ObjectPoolManager.current.CreatePool("Enemy", enemyPrefab, 10);
        enemyPool = objectPool; //ObjectPoolManager.current.CreatePool("Enemies", enemyPrefab, 10);
    }

    private void SpawnEnemy()
    {
        Enemy enemy = enemyPool.Instantiate(Vector3.zero, Quaternion.identity).GetComponent<Enemy>();
    }
}
