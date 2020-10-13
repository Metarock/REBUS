using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private PlayerMovement thePlayer;
    private CameraController theCamera;

    void Start()
    {
        //finds an object in a world that has a PlayerController attached to it
        thePlayer = FindObjectOfType<PlayerMovement>();

        //set the player's transform position as the same as the start point position.
        thePlayer.transform.position = transform.position;

        theCamera = FindObjectOfType<CameraController>();
        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
    }
}
