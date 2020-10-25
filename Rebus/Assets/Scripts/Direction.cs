using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    private int enemyCount;
    public SpriteRenderer spriteRenderer;
    // Cooldown per display
    private bool cooldown = false;

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
            if (cooldown == false)
            {
                // If there are no more enemies, the direction to where the player goes appears.
                this.spriteRenderer.enabled = true;
                Invoke(nameof(ResetCooldown), 2f);
                cooldown = true;
            }

            this.spriteRenderer.enabled = false;

        }
        else
        {
            // DIrection stays disabled as long as there are enemies.
            this.spriteRenderer.enabled = false;
        }

    }

    void ResetCooldown()
    {
        cooldown = false;
    }

}
