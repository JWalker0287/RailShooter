using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public string nameText;
    public string speechText;
    void OnTriggerEnter(Collider c)
    {
        PlayerController p = c.gameObject.GetComponentInParent<PlayerController>();
        if (p != null) 
        {
            TextUIController.textUI.DisplayText(nameText, speechText);
            gameObject.SetActive(false);
        }
    }
}
