using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBarrier : MonoBehaviour
{
    private int enemyCount;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Checks the amount of enemies present in the scene. At the start, it records it.
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks the amount of enemies present in the scene
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount <= 0)
        {
            // If there are no more enemies, the barrier is disabled.
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.spriteRenderer.enabled = false;
        }
        else
        {
            // Barrier stays enabled as long as there are enemies.
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
