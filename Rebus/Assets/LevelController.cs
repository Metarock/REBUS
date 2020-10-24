using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Button houseLevel;
    public Button officeLevel;
    public Button laboratoryLevel;

    int levelPassed;

    // Start is called before the first frame update
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
}
