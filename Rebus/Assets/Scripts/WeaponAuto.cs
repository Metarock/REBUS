using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponAuto : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 100f;

    // Update is called once per frame
    void Update()
    {

        // For shooting
        if (Input.GetButton("Fire1"))
        {

            Shoot();
            // Cancel any shoot() method
            CancelInvoke("Shoot");

        }

        // While the "Fire1" Button is held down
        if (Input.GetButton("Fire1") && !IsInvoking("Shoot"))
        {
            //Execute the Shoot() Method in the next 'number of' seconds
            Invoke("Shoot", 2f);
        }

        // If "Fire1" is released, cancel any scheduled Shoot() method exec.
        if (Input.GetButtonUp("Fire1"))
        {
            //Cancel any Shoot() method code execution
            CancelInvoke("Shoot");
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // Creating bullet and flying at high velocity.
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
