using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCatcher : MonoBehaviour
{

    public string enemyLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(enemyLayer))
        {
            other.transform.position = new Vector3(0.0f, 10.0f, 0.0f);
        }
    }
}
