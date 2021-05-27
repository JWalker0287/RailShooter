using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Start()
    {
        
    }

    public void Play(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Options()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
