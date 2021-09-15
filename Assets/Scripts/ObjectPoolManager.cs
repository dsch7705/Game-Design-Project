using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{

    // Singleton
    public static ObjectPoolManager current;

    // Create list of ObjectPools
    public List<ObjectPool> pools = new List<ObjectPool>();

    private void Start()
    {
        current = this;
    }

    // Creats and adds a new ObjectPool to list, return ObjectPool
    public ObjectPool CreatePool(string name, GameObject prefab, int count)
    {
        if (prefab != null)
        {
            ObjectPool pool = new ObjectPool(name, prefab, count);
            pools.Add(pool);
            return pool;
        }
        Debug.LogWarning("Prefab empty");
        return null;
    }

    // Destroy ObjectPool of given name
    public void DestroyPool(string name)
    {
        foreach (ObjectPool pool in pools)
        {
            if (pool._poolName == name)
            {
                pool.Destroy();
                pools.Remove(pool);
                Debug.Log("Successfully removed ObjectPool");
                return;
            }
        }

        Debug.LogWarning("No ObjectPool of name '" + name + "' exists.");
    }

    // Destroy ObjectPool at given index
    public void DestroyPool(int index) 
    {
        if (pools.Count > index)
        {
            pools[index].Destroy();
            pools.RemoveAt(index);
        }
        else
        {
            Debug.LogWarning("No ObjectPool at index " + index + " exists.");
        }
    }

    //public ObjectPool GetPool(string name)
    //{
    //    foreach (ObjectPool pool in pools)
    //    {
    //        if (pool._poolName == name)
    //        {
    //            return pool;
    //        }
    //    }
    //    Debug.LogWarning("No ObjectPool of name '" + name + "' exists.");
    //    return null;
    //}

    // Remove all items from list
    public void ClearPools()
    {
        pools.Clear();
    }
}
