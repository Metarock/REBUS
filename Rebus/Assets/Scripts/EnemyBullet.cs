using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Effect when it hits an object
    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Quaternion.identity just says no rotation
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroys after .1 seconds
        Destroy(effect, 0.1f);
        Destroy(gameObject);
    }
}
