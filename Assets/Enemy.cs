using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 10;

    public string damagedByLayer;
    public float damageAmount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(damagedByLayer))
        {
            Damage(collision.gameObject.GetComponent<Bullet>()._damage);
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(Player.current.transform.position - transform.position);
        transform.position += Vector3.forward;
    }

    private void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameEvents.current.EnemyKilled();
        GameObject.Destroy(this.gameObject);
    }
}
