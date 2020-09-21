using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public PlayerMovement playermovement;
    public GameObject pistol;

    private void OnTriggerEnter2D(Collider2D test)
    {
        if (test.tag == "Player" && Input.GetKey(KeyCode.G))
        {

            Destroy(pistol);

        }
    }
}
