using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player;
    public static Transform playerPos;
    public float xySpeed = 50;
    public float forwardpeed = 100;
    public float maxVelocityChange = 1;
    public float maxHeight = 30;
    public float maxX = 30;
    Animator anim;
    Rigidbody body;
    Vector3 targetVelocity;
    ProjectileLauncher gun;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        body = gameObject.GetComponent<Rigidbody>();
        gun = gameObject.GetComponentInChildren<ProjectileLauncher>();
        if (player == null) player = this;
        playerPos = transform;
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        targetVelocity = new Vector3(x * xySpeed,-y * xySpeed, forwardpeed);

        Vector3 p = transform.position;
        if (p.x > maxX) p.x = maxX;
        else if (p.x < -maxX) p.x = -maxX;
        if (p.y > maxHeight) p.y = maxHeight;
        else if (p.y < 0) p.y = 0;
        transform.position = p;

        x = body.velocity.x/xySpeed;
        x = body.velocity.x/xySpeed;
        anim.SetFloat("X", x);
        anim.SetFloat("Y", y);

        if (Input.GetButton("Fire1")) gun.Shoot(gun.transform.forward, body.velocity);
    }

    void FixedUpdate()
    {
        Vector3 velocityChange = targetVelocity - body.velocity;
        Vector2 xyChange = (Vector2)velocityChange;

        if (xyChange.sqrMagnitude > maxVelocityChange * maxVelocityChange)
        {
            xyChange = xyChange.normalized * maxVelocityChange;
            velocityChange.x = xyChange.x;
            velocityChange.y = xyChange.y;
        }
        body.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}
