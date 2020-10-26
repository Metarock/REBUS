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

    Scene nextSceneToLoad;

    int levelPassed;
    int sceneIndex;

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
        playerCamera = GameObject.Find("MainCamera");

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
        PlayerPrefs.SetInt("LevelPassed", 1);
        levelCompleteUI.gameObject.SetActive(true);
    }

    //Button Functions (Next Level and Exit)
    public void loadNextLevel()
    {
        SceneManager.LoadScene(nextSceneToLoad.name);
    }

    public void loadMainMenu()
    {
        //Destroy(UIArea);
        //Destroy(player);
        //Destroy(camera);
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
