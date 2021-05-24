using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float lerpSpeed = 10;
    public Vector3 offset = new Vector3(0,1,-10);
    public Transform player;
    public float minHeight = 5;
    public float maxHeight = 20;
    public float maxX = 20;
    Vector3 initialPlayerPosition;
    public float damping = 0.9f;

    void Start()
    {
       initialPlayerPosition = player.position; 
    }

    void FixedUpdate()
    {
        Vector3 p = (player.position - initialPlayerPosition) * damping;
        p.z = 0;
        p = player.position + p + offset;
        if (p.x > maxX) p.x = maxX;
        else if (p.x < - maxX) p.x = -maxX;
        if (p.y > maxHeight) p.y = maxHeight;
        else if (p.y < minHeight) p.y = minHeight;
        transform.position = p;
    }
}
