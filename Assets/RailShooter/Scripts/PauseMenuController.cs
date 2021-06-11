using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseRoot;
    void Start()
    {
        pauseRoot.SetActive(false);
    }
    void Awake ()
    {
        pauseRoot.SetActive(false);
    }
    public void PauseResume()
    {
        pauseRoot.SetActive(!pauseRoot.activeSelf);
        if(pauseRoot.activeSelf)
        {
            Time.timeScale = 0;
            EventSystem.current.SetSelectedGameObject(pauseRoot.transform.GetChild(0).gameObject);
        }
        else
        {
            Time.timeScale = 1;
        }
    }

     void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        pauseRoot.SetActive(false);
    }


    void Update()
    {
        if (Input.GetButtonDown("Cancel")) PauseResume();
    }
}
