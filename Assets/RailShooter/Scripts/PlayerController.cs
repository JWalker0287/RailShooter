using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player;
    public static Transform playerPos;
    public float xySpeed = 50;
    public float forwardpeed = 100;
    public float maxVelocityChange = 2;
    public float maxHeight = 30;
    public float maxX = 30;
    public float targetRotation;
    float lastShot;
    public bool allRangeMode = false;

    bool charging = false;
    Transform lockTarget;
    public SpriteRenderer farReticle;
    public SpriteRenderer closeReticle;

    Vector3 targetVelocity;
    Animator anim;
    Rigidbody body;
    public ProjectileLauncher gun;
    //public Projectile bomb;
    public Projectile chargeShot;

    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        body = gameObject.GetComponent<Rigidbody>();
        gun = gameObject.GetComponentInChildren<ProjectileLauncher>();
        if (player == null) player = this;
        playerPos = transform;
        chargeShot.gameObject.SetActive(false);
        chargeShot.transform.SetParent(null);
//        bomb.gameObject.SetActive(false);
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float z = forwardpeed;

        //farReticle.transform.up = Vector3.up;
        //closeReticle.transform.up = Vector3.up;
        
        if(allRangeMode)
        {
            targetVelocity = transform.right * x - Vector3.up * y * xySpeed + transform.forward * z;
            targetRotation = x *  xySpeed;
            Vector3 p = transform.position;
            if (p.y > maxHeight) p.y = maxHeight;
            else if (p.y < 0) p.y = 0;
            transform.position = p;
        }
        else
        {
            targetRotation = 0;
            targetVelocity = new Vector3(x * xySpeed,-y * xySpeed, forwardpeed);
            Vector3 p = transform.position;
            if (p.x > maxX) p.x = maxX;
            else if (p.x < -maxX) p.x = -maxX;
            if (p.y > maxHeight) p.y = maxHeight;
            else if (p.y < 0) p.y = 0;
            transform.position = p;
            x = body.velocity.x/xySpeed;
        }


        y = body.velocity.y/xySpeed;
        anim.SetFloat("X", x);
        anim.SetFloat("Y", -y);

        if (Input.GetButtonDown("Fire1"))
        {
            lastShot = Time.time;
            gun.Shoot(gun.transform.forward, body.velocity);
        }
        else if (!charging && Input.GetButton("Fire1") && Time.time - lastShot > 0.5f)
        {
            charging = true;
            StartCoroutine(ChargeShotCoroutine());
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(ChargeShotCoroutine());
            if (charging)
            {
                chargeShot.transform.position = gun.transform.position;
                chargeShot.Fire(gun.transform.forward, body.velocity);
                //chargeShot.target = lockTarget;
                //lockTarget = null;
            }
            StopCharging();
        }
        else if (Input.GetButton("Fire2"))
        {
            //bomb.transform.SetParent(null);
            //bomb.transform.position = gun.transform.position;
            //bomb.Fire(gun.transform.forward, body.velocity);
        }
    }
    void StopCharging()
    {
        StopCoroutine(ChargeShotCoroutine());
        charging = false;
        farReticle.color = Color.green;
        closeReticle.color = Color.green;
    }
    IEnumerator ChargeShotCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        charging = true;
        yield return new WaitForSeconds(0.5f);
        closeReticle.color = Color.yellow;
        farReticle.color = Color.red;
        while(charging)
        {
            for (float t = 0; t <= 0.5f; t += Time.deltaTime)
            {
                farReticle.transform.localScale = Vector3.one * Mathf.Lerp(8, 6, t/0.5f);
                yield return new WaitForEndOfFrame();

                // if (lockTarget == null)
                // }
                //     Vector3 pos = cam.WorldToScreenPoint(farReticle.transform.position);
                //     Ray ray = cam.ScreenPointToRay(pos);
                //     RaycastHit[] hits = Physics.SphereCastAll(ray, 5, 500);
                //     for (int i = 0; i < hits.Length; i ++)
                //     {
                //         if (hits[i].rigidbody && hits[i].rigidbody.CompareTag("Enemy"))
                //         {
                //             lockTarget = hits[i].rigidbody.transform;
                //             break;
                //         }
                //     }
                // {
                // else 
                // {

                // }
            }
        }
        farReticle.transform.localScale = Vector3.one * 4;
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * targetRotation * Time.fixedDeltaTime);

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
