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

    public static bool UIExists;

    // Start is called before the first frame update
    public void Start()
    {
        if (!UIExists)
        {
            UIExists = true;
            pauseUI.SetActive(false);
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void Update()
    {
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
    }


    public void Resume()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        paused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
        paused = true;

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        //not implemented due to not required
        //Application.Quit();
    }


}
