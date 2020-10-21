using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageIndicator : MonoBehaviour
{
    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        // Checks the amount of enemies present in the scene. At the start, it records it.
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("Start!");
        this.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks the amount of enemies present in the scene
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("Message: " + enemyCount);

        if (enemyCount <= 0)
        {
            this.GetComponent<Text>().enabled = true;
            Debug.Log("True!");
        }

    }
}
