using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    GameObject player;
    GameObject mainCamera;
    GameObject UIArea;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
        UIArea = GameObject.Find("UIArea");

        ActivatePlayerObjects();
    }

    void ActivatePlayerObjects()
    {
        /*player.SetActive(true);
        mainCamera.SetActive(true);
        UIArea.SetActive(true);*/
        player.GetComponent<PlayerHealthManager>().RestoreCurrentHealth();

    }
}
