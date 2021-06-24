using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }

    public void ToggleScreens(GameObject screen)
    {
        screen.gameObject.SetActive(!screen.activeSelf);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Options()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
