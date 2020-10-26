using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuLevelController : MonoBehaviour
{
    public Button houseLevel;
    public Button officeLevel;
    public Button laboratoryLevel;

    int levelPassed;
    float runtime;

    // Start is called before the first frame update
    //Checks playerprefs to see which levels are to be unlocked (all levels - except house level - are disabled/locked by default)
    void Start()
    {
        runtime = Time.time;

        officeLevel.interactable = false;
        laboratoryLevel.interactable = false;

        levelPassed = PlayerPrefs.GetInt("LevelPassed");

        if(runtime > 0.1f)
        {
            switch (levelPassed)
            {
                case 1:
                    officeLevel.interactable = true;
                    Debug.Log("PlayerPrefs LevelPassed is now set to 1");
                    break;
                case 2:
                    officeLevel.interactable = true;
                    laboratoryLevel.interactable = true;
                    Debug.Log("PlayerPrefs LevelPassed is now set to 2");
                    break;
            }
        }
        else
        {
            PlayerPrefs.SetInt("LevelPassed", 0);
            levelPassed = PlayerPrefs.GetInt("LevelPassed");
            Debug.Log("PlayerPrefs LevelPassed is now set to 0");
        }

        
    }

    //Reset player progress. This resets all levels and will lock all currently unlocked levels.
    public void ResetProgress()
    {
        PlayerPrefs.SetInt("LevelPassed", 0);
        levelPassed = PlayerPrefs.GetInt("LevelPassed");

        officeLevel.interactable = false;
        laboratoryLevel.interactable = false;
    }
}
