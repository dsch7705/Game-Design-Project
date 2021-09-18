using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 10;

    public string damagedByLayer;
    public float damageAmount;

    private void OnEnable()
    {
        health = 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(damagedByLayer))
        {
            Debug.Log("LIBTARD");
            Bullet _bullet = collision.gameObject.GetComponent<Bullet>();
            if (_bullet._canDamage)
            {
                Damage(_bullet._damage);
                AudioManager.current.PlayClip(GameAssets.current.hitAudioClips[0]);

                _bullet._canDamage = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 lookPos = Player.current.transform.position - transform.position;

        transform.rotation = Quaternion.LookRotation(lookPos, Vector3.up); //Quaternion.Euler(0.0f, Mathf.Atan((Player.current.transform.position.y - transform.position.y) / (Player.current.transform.position.x - transform.position.x)), 0.0f);
        transform.position += transform.forward * 0.05f;
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
        EnemyManager.current.DestroyEnemy(gameObject);

        GameEvents.current.SpawnEnemy();
    }
}
