using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultCarrierController : MonoBehaviour
{
    Rigidbody body;
    float forwardSpeed;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        forwardSpeed = PlayerController.player.forwardpeed;
        
    }
    void Start()
    {
        body.velocity = PlayerController.player.body.velocity;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //Vector3 movement = Vector3.forward * forwardSpeed;
        //body.AddForce(movement, ForceMode.VelocityChange);
        //body.velocity = PlayerController.player.body.velocity;
    }
}
