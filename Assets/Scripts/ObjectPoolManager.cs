using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectPoolManager
{
    // Create list of ObjectPools
    public static List<ObjectPool> pools = new List<ObjectPool>();

    // Creats and adds a new ObjectPool to list, return ObjectPool
    public static ObjectPool CreatePool(string name, GameObject prefab, int count)
    {
        ObjectPool pool = new ObjectPool(name, prefab, count);
        pools.Add(pool);
        return pool;
    }

    // Destroy ObjectPool of given name
    public static void DestroyPool(string name)
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
    public static void DestroyPool(int index) 
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

    //public static ObjectPool GetPool(string name)
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
    public static void ClearPools()
    {
        pools.Clear();
    }
}
