using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MessageIndicator : MonoBehaviour
{
    private int enemyCount;
    Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        // Checks the amount of enemies present in the scene. At the start, it records it.
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        this.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks the amount of enemies present in the scene
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        scene = SceneManager.GetActiveScene();

        if (enemyCount <= 0 && scene.name != "MainMenu")
        {
            this.GetComponent<Text>().enabled = true;
        }
    }
}
