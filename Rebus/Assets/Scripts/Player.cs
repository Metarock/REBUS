using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // For scene changing
    public VectorValue startingPosition;

    void Start()
    {
        // For Loading a new Scene
        transform.position = startingPosition.initialValue;
    }

}
