using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Enemy vars
    public float health = 10;
    public LayerMask damagedByLayer;
    public float damageAmount;
    public int enemyID;

    private void OnEnable()
    {
        health = 10;
        //Debug.Log("Enemy " + gameObject.GetInstanceID() + " enabled.");
    }

    private void OnDisable()
    {
        //Debug.Log("Enemy " + gameObject.GetInstanceID() + " disabled.");
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    // Check if collision is with bullet layer
    //    int layer = collision.gameObject.layer;
    //    if (damagedByLayer == 1 << layer)
    //    {
    //        // Get Bullet object, check if damage capable, do damage things
    //        Bullet _bullet = collision.gameObject.GetComponent<Bullet>();
    //        if (_bullet._canDamage)
    //        {
    //            Damage(_bullet._damage);
    //            AudioManager.current.PlayClip(GameAssets.current.hitAudioClips[0]);
    //
    //            _bullet._canDamage = false;
    //        }
    //    }
    //}

    private void FixedUpdate()
    {
        // Very stupid enemy "AI"
        Vector3 lookPos = Player.current.transform.position - transform.position;

        transform.rotation = Quaternion.LookRotation(lookPos, Vector3.up); //Quaternion.Euler(0.0f, Mathf.Atan((Player.current.transform.position.y - transform.position.y) / (Player.current.transform.position.x - transform.position.x)), 0.0f);
        transform.position += transform.forward * 0.05f;
    }

    public void Damage(float damage)
    {
        health -= damage;
        AudioManager.current.PlayClip(GameAssets.current.hitAudioClips[0]);

        Debug.Log("Enemy " + gameObject.GetInstanceID() + " took " + damage + " damage.");
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameEvents.current.EnemyKilled();
        //EnemyManager.current.DestroyEnemy(gameObject);

        //Debug.Log(gameObject.GetInstanceID() + "destroyed");
        GameEvents.current.SpawnEnemy();
        GameObject.Destroy(gameObject);
    }

    IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(0.25f);
    }
}
