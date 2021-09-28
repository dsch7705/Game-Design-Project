using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask ricochetLayer;
    public LayerMask damageLayer;

    public float _damage;
    public bool _canDamage;

    public void InitializeBullet(float damage)
    {
        _damage = damage;
        _canDamage = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        int layer = collision.gameObject.layer;
        if (damageLayer == 1 << layer && _canDamage)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Damage(_damage);

            _canDamage = false;
        }
        else if (ricochetLayer != 1 << layer)
        {
            _canDamage = false;
        }
    }
}
