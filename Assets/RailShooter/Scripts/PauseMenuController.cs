using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseRoot;
    public void PauseResume()
    {
        pauseRoot.SetActive(!pauseRoot.activeSelf);
        if(pauseRoot.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel")) PauseResume();
    }
}
