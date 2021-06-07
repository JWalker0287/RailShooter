using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    void Update()
    {
        float zDist = (transform.position.z - PlayerController.player.transform.position.z);
        if (zDist <= 0) 
        {
            Debug.Log("Here");
            GameManager.game.ReloadScene();
            
        }
    }
}
