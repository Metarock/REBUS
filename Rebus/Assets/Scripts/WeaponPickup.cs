using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    public GameObject[] weapons;
    public GameObject currentweapon;

    // Start is called before the first frame update
    void Start()
    {
        currentweapon = weapons[Random.Range(0,weapons.Length)];
        GetComponent<SpriteRenderer>().sprite = currentweapon.GetComponent<SpriteRenderer>().sprite;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

        }
    }
}
