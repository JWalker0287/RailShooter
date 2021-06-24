using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public float speed = 200;
    public Transform anchor;
    public float maxRange = 3000;
    public float maxHeight = 30;
    public float maxX = 30;
    Vector3 targetVelocity;
    Vector3 targetPosition;
    float targetRotation;
    Animator anim;
    Rigidbody body;

    void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    IEnumerator Start()
    {
        while(enabled)
        {
            yield return new WaitForSeconds(3);
        }
    }

    void UpdateTargetPosition()
    {
        targetPosition = Random.insideUnitSphere * maxRange + anchor.position;
        targetPosition.y = Random.Range(0,maxHeight); 
    }

    void Update()
    {
        Vector3 diff = targetPosition - transform.position;
        if (diff.magnitude < 50) UpdateTargetPosition();
        targetVelocity = transform.forward * speed + Vector3.up * diff.y;
        anim.SetFloat("Y", -2 * diff.y/maxHeight);
        diff.y = 0;
        diff.Normalize();
        float cross = Vector3.Cross(transform.forward, diff).y;
        anim.SetFloat("X",cross);
        transform.Rotate(Vector3.up * cross * Time.deltaTime);
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * targetRotation * Time.fixedDeltaTime);

        Vector3 velocityChange = targetVelocity - body.velocity;

        if (velocityChange.sqrMagnitude > 1)
        {
            velocityChange = velocityChange.normalized;
        }
        body.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}
