using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCurrentHealth <= 0)
        {
            //gameObject.SetActive(false);
            FindObjectOfType<RespawnManager>().Restart();
        }
    }

    public void PlayerIsDamaged(int damageToPlayer)
    {
        playerCurrentHealth -= damageToPlayer;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

}
