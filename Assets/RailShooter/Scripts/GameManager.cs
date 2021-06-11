using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager game;
    public Text ringText;
    public int ringsPassed = 0;
    public Text killText;
    int killCount = 0;
    public Image healthBar;
    public HealthController playerHealth;
    void Awake()
    {
        if (game == null)game = this;
        Time.timeScale = 1;
    }

    void OnEnable()
    {
        HealthController.onAnyDeath += DeathCallback;
    }

    void OnDisable()
    {
        HealthController.onAnyDeath -= DeathCallback;
    }

    void Update()
    {
        ringText.text = ringsPassed.ToString("000");
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

    void DeathCallback(HealthController enemy)
    {
        if (enemy.gameObject.CompareTag("Enemies"))
        {
            killCount ++;
            killText.text = killCount.ToString("000");
        }
        else if (enemy.gameObject.CompareTag("Player"))
        {
            //death screen
        }
    }
}
