using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    GameObject levelCompleteUI;
    GameObject player;
    GameObject UIArea;
    GameObject camera;

    int levelPassed;
    int sceneIndex;

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
        camera = GameObject.Find("MainCamera");

        levelCompleteUI = GameObject.Find("LevelCompleteUI");
        levelCompleteUI.gameObject.SetActive(false);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        levelPassed = PlayerPrefs.GetInt("LevelPassed");
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
        SceneManager.LoadScene("OfficeFloorBasement");
    }

    public void loadMainMenu()
    {
        //Destroy(UIArea);
        //Destroy(player);
        //Destroy(camera);
        SceneManager.LoadScene("MainMenu");
    }
}
