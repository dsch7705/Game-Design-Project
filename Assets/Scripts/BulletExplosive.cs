using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosive : Bullet
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {

        }
    }

    //private 
}
