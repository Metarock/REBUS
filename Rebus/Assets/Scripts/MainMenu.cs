using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Function to start game (for PLAY button)
    public void PressPlay()
    {
        FindObjectOfType<AudioManager>().Stop("mainMenuTheme");
        FindObjectOfType<AudioManager>().Play("levelTheme");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Function to quit game (for QUIT button)
    public void QuitGame()
    {
        Application.Quit();
    }
}
