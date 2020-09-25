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

    //Function to play office level
    public void PlayOfficeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    //Function to play house level -- NEEDS FIX
    public void PlayHouseLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
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
