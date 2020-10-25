using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    void ResetPlayer()
    {
        player.GetComponent<PlayerHealthManager>().RestoreCurrentHealth();
    }
}
