using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paraphernalia.Extensions;

public class CameraController : MonoBehaviour
{
    public float lerpSpeed = 30;
    public Vector3 offset = new Vector3(0,1,-10);
    public Transform player;
    Vector3 initialPlayerPosition;
    public float damping = 0.9f;

    void Start()
    {
       initialPlayerPosition = player.position; 
    }

    #if UNITY_EDITOR
    void Update()
    {
        if (!Application.isPlaying) transform.position = player.position + offset;
    }
    #endif

    void FixedUpdate()
    {
        Vector3 off = player.right * offset.x + player.up * offset.y + player.forward * offset.z;
        transform.position = Vector3.Lerp(transform.position,
            player.position + off,
            Time.deltaTime * lerpSpeed
        );
        Vector3 dir = PlayerController.player.farReticle.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(
         transform.rotation,
         Quaternion.LookRotation(dir, Vector3.up), 
         Time.deltaTime * lerpSpeed);
    }
}
