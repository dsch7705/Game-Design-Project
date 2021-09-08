using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    public string _poolName;
    public GameObject _prefab;
    public int _count;
    public GameObject _emptyPool;

    GameObject pool;

    public ObjectPool(string poolName, GameObject prefab, int count, GameObject emptyPool)
    {
        _poolName = poolName;
        _prefab = prefab;
        _count = count;
        _emptyPool = emptyPool;

        Awake();
    }

    private void Awake()
    {
        pool = GameObject.Instantiate(_emptyPool);
        pool.name = _poolName;

        for (int i = 0; i < _count; i++)
        {
            GameObject _item = GameObject.Instantiate(_prefab, pool.transform);
        }
    }
}
