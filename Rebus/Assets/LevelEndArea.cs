using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndArea : MonoBehaviour
{
    private int enemyCount;

    void Start()
    {
        // Checks the amount of enemies present in the scene. At the start, it records it.
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks the amount of enemies present in the scene
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    //Function occurs when the player enters this collider.
    void OnTriggerEnter2D(Collider2D theCollider)
    {
        // If Player Tag is recognized, then level end UI will appear.
        if ((theCollider.CompareTag("Player") && !theCollider.isTrigger) && enemyCount == 1)
        {
            LevelController.instance.LevelComplete();
        }
    }
}
