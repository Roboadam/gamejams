using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 vel = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            movement += Vector3.forward;
        }
        if(Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
        }
        if(Input.GetKey(KeyCode.S))
        {
            movement += Vector3.back;
        }
        if(Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
        }

        vel = movement.normalized * 2;
        rigidbody.velocity = vel;
    }

    void FixedUpdate()
    {
        Debug.Log("velocity changed to " + vel);

    }
}
