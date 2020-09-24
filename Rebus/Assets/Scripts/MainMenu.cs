using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    //Function to start game (for PLAY button)
    public void PressPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Function to quit game (for QUIT button)
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ButtonSound()
    {
        audioManager.buttonPress.Play();
    }
}
