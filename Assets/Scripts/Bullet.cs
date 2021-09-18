using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string damageLayer;
    public float _damage;
    public bool _canDamage;

    public void InitializeBullet(float damage)
    {
        _damage = damage;
        _canDamage = true;
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer(damageLayer))
    //    {
    //        _canDamage = false;
    //        Debug.Log("collided with enemy");
    //    }
    //}
}
