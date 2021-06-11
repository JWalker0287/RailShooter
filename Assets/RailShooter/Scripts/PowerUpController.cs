using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public string prefabName = "TwinLasers";

    void OnTriggerEnter (Collider c)
    {
        PlayerController p = c.gameObject.GetComponentInParent<PlayerController>();
        if (p == null) return;

        ProjectileLauncher gun = p.gameObject.GetComponentInChildren<ProjectileLauncher>();
        gun.projectileName = prefabName;
        gameObject.SetActive(false);
    }
}
