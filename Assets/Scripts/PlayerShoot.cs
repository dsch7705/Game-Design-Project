using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    ObjectPool bulletPool;

    public int bulletPoolAmount;
    public float shootForce;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = ObjectPoolManager.CreatePool("Bullets", bullet, bulletPoolAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if /*(Input.GetAxisRaw("Shoot") > 0 ||*/ (Input.GetMouseButtonDown(0))
        {
            GameObject _bullet = bulletPool.Instantiate(transform.position, Quaternion.Euler(Vector3.zero));
            Rigidbody rb = _bullet.GetComponent<Rigidbody>();
        
            rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);
        }
    }
}
