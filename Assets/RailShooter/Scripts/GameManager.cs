using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager game;
    public Text ringText;
    public int ringsPassed = 0;
    public GameObject deathScreen;
    public Text killText;
    int killCount = 0;
    public Image healthBar;
    public HealthController playerHealth;
    void Awake()
    {
        if (game == null)game = this;
        Time.timeScale = 1;
        deathScreen.SetActive(false);
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
    }

    void OnEnable()
    {
        HealthController.onAnyDeath += DeathCallback;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        HealthController.onAnyDeath -= DeathCallback;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        deathScreen.SetActive(false);
        Time.timeScale = 1;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
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

    void DeathCallback(HealthController health)
    {
        if (health.gameObject.CompareTag("Enemies"))
        {
            killCount ++;
            killText.text = killCount.ToString("000");
            return;
        }

        PlayerController player = health.GetComponent<PlayerController>();

        if (player != null)
        {
            deathScreen.SetActive(true);
            EventSystem.current.SetSelectedGameObject(deathScreen.transform.GetChild(0).gameObject);
        }
    }
}
