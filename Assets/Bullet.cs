using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float _damage;

    public void InitializeBullet(float damage)
    {
        _damage = damage;
    }
}
