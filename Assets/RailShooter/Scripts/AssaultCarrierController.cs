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
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 movement = PlayerController.player.body.velocity.z * Vector3.forward;
        //body.AddForce(movement, ForceMode.VelocityChange);
        body.velocity = movement;
    }
}
