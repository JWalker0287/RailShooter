using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform turret;
    public Transform turretBarrel;
    ProjectileLauncher gun;
    Rigidbody player;
    [Range(0,1)] public float lookAhead = 1;
    public float yCorrection = 1;
    public float gunRange = 30;
    void Awake()
    {
        gun = GetComponentInChildren<ProjectileLauncher>();
    }
    void Start()
    {
        player = PlayerController.player.GetComponent<Rigidbody>();
    }
    void Update()
    {
        float zDist = (transform.position.z - player.transform.position.z);
        Vector3 velo = player.velocity;
        Vector3 diff = player.transform.position - transform.position;
        float t = diff.magnitude/ velo.magnitude;
        Vector3 aim = diff + velo * t * lookAhead;
        aim.y -= yCorrection;
        turret.forward = new Vector3(aim.x, 0, aim.z);
        turretBarrel.forward = aim;

        if (zDist <= gunRange && zDist >= 0)
        {
            gun.Shoot(gun.transform.forward);
        }
    }
}
