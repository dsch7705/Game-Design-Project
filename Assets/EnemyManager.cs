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

        ObjectPool objectPool = ObjectPoolManager.current.CreatePool("Enemy", enemyPrefab, 10, false);
        enemyPool = objectPool; //ObjectPoolManager.current.CreatePool("Enemies", enemyPrefab, 10);

        SpawnEnemy();
    }

    public void DestroyEnemy(GameObject enemy)
    {
        //enemyPool.Destroy(enemy);
    }

    public void SpawnEnemy()
    {
        Enemy enemy = enemyPool.Instantiate(new Vector3(0f, 10f, 0f), Quaternion.identity).GetComponent<Enemy>();
    }
}
