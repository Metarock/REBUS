using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public string sceneToLoad;
    //public Vector2 playerPosition;
    public VectorValue playerStorage;

    void OnTriggerEnter2D(Collider2D other)
    {
        // If Player Tag is recognized, then it loads the selected scene
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //playerStorage.initialValue = playerPosition;

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
