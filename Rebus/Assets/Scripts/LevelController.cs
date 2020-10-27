using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    GameObject levelCompleteUI;
    public GameObject levelEndMessage;
    GameObject player;
    GameObject UIArea;
    GameObject playerCamera;

    public string nextLevelString;

    int levelPassed;
    int sceneIndex;

    public int levelPassedNumber;

    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        player = GameObject.Find("Player");
        UIArea = GameObject.Find("UIArea");
        playerCamera = GameObject.Find("Main Camera");

        levelCompleteUI = GameObject.Find("LevelCompleteUI");
        levelCompleteUI.gameObject.SetActive(false);

        levelEndMessage.SetActive(false);

        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        levelPassed = PlayerPrefs.GetInt("LevelPassed");
    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount >= 1)
        {
            LevelEndMessageCheck();
        }
        
    }

    //Allows the level complete UI to appear once the level has been completed.
    public void LevelComplete()
    {
        PlayerPrefs.SetInt("LevelPassed", levelPassedNumber);
        levelCompleteUI.gameObject.SetActive(true);
    }

    //Button Function to load the next level (the next level is determined by the String variable nextLevelString)
    public void loadNextLevel()
    {
        FindObjectOfType<PlayerHealthManager>().playerCurrentHealth = FindObjectOfType<PlayerHealthManager>().playerMaxHealth;

        SceneManager.LoadScene(nextLevelString);
    }

    //Button Function to load the main menu scene.
    public void loadMainMenu()
    {
        FindObjectOfType<PlayerHealthManager>().playerCurrentHealth = FindObjectOfType<PlayerHealthManager>().playerMaxHealth;

        SceneManager.LoadScene("MainMenu");
    }

    //Checks the amount of enemies present in the scene and if there is a LevelEndArea object present (FOR LEVEL END MESSAGE)
    void LevelEndMessageCheck()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 1 && levelCompleteUI.activeSelf == false)
        {
            levelEndMessage.SetActive(true);
        }
        else
        {
            levelEndMessage.SetActive(false);
        }
    }
    
}
