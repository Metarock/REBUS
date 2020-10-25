using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{

    Vector2 playerInitPosition;
    private void Start()
    {
        playerInitPosition = FindObjectOfType<PlayerMovement>().transform.position;
    }
    //Restart Level
    public void Restart()
    {
        //1 - Restart the scene 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //2 - Reset the player's position
        //Save the player's intial position when game starts
        //When respawning simply reposition the player to that init positions
        //FindObjectOfType<PlayerMovement>().resetPlayer();
        FindObjectOfType<PlayerHealthManager>().playerCurrentHealth = FindObjectOfType<PlayerHealthManager>().playerMaxHealth;
        FindObjectOfType<PlayerMovement>().resetPlayer();
        FindObjectOfType<PlayerMovement>().transform.position = playerInitPosition;
    }
}
