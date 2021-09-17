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
        Vector3 lookPos = Player.current.transform.position - transform.position;

        transform.rotation = Quaternion.LookRotation(lookPos, Vector3.up); //Quaternion.Euler(0.0f, Mathf.Atan((Player.current.transform.position.y - transform.position.y) / (Player.current.transform.position.x - transform.position.x)), 0.0f);
        transform.position += transform.forward * 0.01f;
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
        GameEvents.current.SpawnEnemy();

        EnemyManager.current.DestroyEnemy(gameObject);
    }
}
