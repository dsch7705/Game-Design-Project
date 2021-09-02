using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    PlayerMovement player;
    public int jumpMask;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == 6)
        {
            player.isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.layer == 6)
        {
            player.isGrounded = false;
        }
    }
}
