using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public PlayerHealthManager playerHealth;
    public GameObject eliminatedMessage;
    private int enemyCount;

    public static bool UIExists;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
            Debug.Log("Start!");
            eliminatedMessage.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;

        // Checks the amount of enemies present in the scene
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("Message: " + enemyCount);

        if (enemyCount <= 0)
        {
            eliminatedMessage.SetActive(true);
            Debug.Log("True!");
        }
        else
        {
            eliminatedMessage.SetActive(false);
        }
    }
}
