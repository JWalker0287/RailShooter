using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    Transform playerPos;
    public float detectDist = 8;
    void Awake()
    {
        playerPos = PlayerController.playerPos;
    }

    void Update()
    {
        playerPos = PlayerController.playerPos;
        float x1 = transform.position.x;
        float y1 = transform.position.y;
        float x2 = playerPos.position.x;
        float y2 = playerPos.position.y;
        float zDist = transform.position.z - playerPos.position.z;
        float xyDist = Mathf.Abs(Mathf.Sqrt(Mathf.Pow((x2-x1), 2) + Mathf.Pow((y2-y1), 2)));
        if (zDist <= 0)
        {
            if (xyDist <= detectDist)
            {
                AddToCount();
                this.enabled = false;
            }
            else
            {
                ResetCount();
                this.enabled = false;
            }
        }
        
    }

    void AddToCount()
    {
        Debug.Log("Add To Count");
    }

    void ResetCount()
    {
        Debug.Log("Reset Count");
    }
}
