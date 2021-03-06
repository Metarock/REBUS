﻿using System.Collections;
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
        SceneManager.LoadScene("OfficeBasement"); //Goes to Office basement floor
    }

    //Function to play house level
    public void PlayHouseLevel()
    {
        SceneManager.LoadScene("HouseFirstFloor"); //Goes to House first floor
    }

    //Function to play laboratory level
    public void PlayLaboratoryLevel()
    {
        SceneManager.LoadScene("LaboratoryFloor1"); //Goes to Laboratory first floor
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
