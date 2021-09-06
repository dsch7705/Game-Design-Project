using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementV2 : MonoBehaviour
{
    CharacterController controller;
    public Transform movementHelper;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        movementHelper.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(xMove, 0.0f, zMove).normalized * Time.deltaTime;
        movementHelper.position += move;

        controller.Move(move);

    }
}
