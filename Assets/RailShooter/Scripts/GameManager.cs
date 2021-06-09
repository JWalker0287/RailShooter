using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int ringsPassed = 0;
    public static GameManager game;
    public Text ringText;
    public Image healthBar;
    public HealthController playerHealth;
    void Awake()
    {
        if (game == null)game = this;
        Time.timeScale = 1;
    }
    void Update()
    {
        ringText.text = ringsPassed.ToString();
        healthBar.fillAmount = playerHealth.healthPct;
    }

    public void ReloadScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
    }

    IEnumerator LoadScene(string name)
    {
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene("Training");

    }
}
