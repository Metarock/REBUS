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

    // Start is called before the first frame update
    //Checks playerprefs to see which levels are to be unlocked (all levels - except hosue level - are disabled/locked by default)
    void Start()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");

        officeLevel.interactable = false;
        laboratoryLevel.interactable = false;

        switch (levelPassed)
        {
            case 1:
                officeLevel.interactable = true;
                break;
            case 2:
                officeLevel.interactable = true;
                laboratoryLevel.interactable = true;
                break;
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
