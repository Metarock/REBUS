using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool paused = false;

    public GameObject pauseUI;
    public Slider healthBar;
    public PlayerHealthManager playerHealth;
    public GameObject eliminatedMessage;
    private int enemyCount;

    public static bool UIExists;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
            eliminatedMessage.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Checks whenever the escape key is pressed. Pressing the escape key will make the pause menu appear.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;

        EliminatedMessageCheck();
    }


    // Checks the amount of enemies present in the scene (FOR ELIMINATED MESSAGE)
    void EliminatedMessageCheck()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount <= 0)
        {
            eliminatedMessage.SetActive(true);
        }
        else
        {
            eliminatedMessage.SetActive(false);
        }
    }

    //PAUSE FUNCTIONS


    //Resumes the game
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        paused = false;
    }

    //Pauses the game
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
        paused = true;

    }

    //Loads the main menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
