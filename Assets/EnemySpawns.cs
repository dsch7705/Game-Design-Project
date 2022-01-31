using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour
{
    public static EnemySpawns current;
    public List<Transform> spawns = new List<Transform>();

    void Start()
    {
        current = this;

        foreach (Transform child in transform)
        {
            spawns.Add(child);
        }
    }
    
    public Transform PickRandomSpawn()
    {
        int spawn = Random.Range(0, spawns.Count - 1);
        return (spawns[spawn]);
    }
}
