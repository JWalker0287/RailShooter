using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultCarrierController : MonoBehaviour
{
    Rigidbody body;
    Animator anim;
    float lastAttackTime = 0;
    //float forwardSpeed;

    bool[] doorOpen = new bool[2];

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        doorOpen[0] = false;
        doorOpen[1] = false;
        //forwardSpeed = PlayerController.player.forwardpeed;
        
    }
    void Start()
    {
        StartCoroutine(StartBossBattle());
    }

    void Update()
    {
        if (lastAttackTime >= 5)
        {
            ToggleDoorOpen(1);
            lastAttackTime = 0;
        }
        lastAttackTime += Time.deltaTime;
    }

    void FixedUpdate()
    {
        Vector3 movement = PlayerController.player.body.velocity.z * Vector3.forward;
        //body.AddForce(movement, ForceMode.VelocityChange);
        body.velocity = movement;
    }

    void ToggleDoorOpen(int doorIndex)
    {
        if (doorOpen[doorIndex])
        {
            anim.Play("CloseHangar" + doorIndex.ToString());
        }
        else
        {
            anim.Play("OpenHangar" + doorIndex.ToString());
        }
    }

    IEnumerator StartBossBattle()
    {
        yield return new WaitForSeconds(5);
        anim.Play("facePlayer");
        yield return new WaitForSeconds(2);
    }

}
