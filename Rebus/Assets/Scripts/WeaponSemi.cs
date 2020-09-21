using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSemi : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    // Fire Rate of the Bullet
    public float fireRate;
    public float bulletForce = 30f;

    // Update is called once per frame
    void Update()
    {

        // For shooting
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();           
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