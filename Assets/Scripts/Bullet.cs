using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask bulletLayer;
    public LayerMask damageLayer;
    public LayerMask explosionLayer;

    public float _damage;
    public bool _canDamage;
    public int _ammoType;

    public float bulletLifespan;
    public int bounceLimit;
    int bulletCollisions;

    //public ObjectPool _bulletPool;

    private void Awake()
    {
        //_bulletPool = PlayerShoot.current.GetBulletPool();
    }

    public void InitializeBullet(float damage, int ammoType)
    {
        _damage = damage;
        _canDamage = true;
        _ammoType = ammoType;
    }

    private void OnCollisionEnter(Collision collision)
    {
        int layer = collision.gameObject.layer;
        switch (_ammoType)
        {
            // Normal ammo
            case 0:
                Debug.Log("Normal ammo collided.");
                if (damageLayer == 1 << layer && _canDamage)
                {
                    Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                    enemy.Damage(_damage);

                    _canDamage = false;
                    //Debug.Log("Bullet damage disabled");
                }
                else if (bulletLayer != 1 << layer && bulletCollisions < bounceLimit)
                {
                    bulletCollisions++;
                    if (bulletCollisions >= bounceLimit)
                    {
                        //Debug.Log("bounce limit reached");
                        _canDamage = false;

                    }
                }

                break;

            // Explosive ammo
            case 1:
                Debug.Log("Explosive ammo collided.");
                if (explosionLayer == 1 << layer && _canDamage)
                {
                    _canDamage = false;
                    for (int i = 0; i < 50; i++)
                    {
                        Debug.Log(i);
                        PlayerShoot.current.Shoot(1);
                        //GameObject fragment = PlayerShoot.current.bulletPool.Instantiate(transform.position, Quaternion.Euler(Vector3.zero));
                        //Bullet fragmentBulletObject = fragment.GetComponent<Bullet>();
                        //fragmentBulletObject.InitializeBullet(_damage, 0);
                    }

                }
                break;
        }
        
    }

    IEnumerator BulletLifespan()
    {
        yield return new WaitForSeconds(bulletLifespan);
    }
}
