using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShotgun : MonoBehaviour
{
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject bulletPrefab;
    // Fire Rate of the Bullet
    public float bulletForce = 50f;
    // Added cooldown per shot to prevent spamming
    private bool cooldown = false;


    void Update()
    {
        if (cooldown == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                // This prevents the player from spamming the shotgun. Shoots only once per second.
                Invoke(nameof(ResetCooldown), 1f);
                cooldown = true;
            }

        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }

    void Shoot()
    {
        GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);

        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();

        // Creating bullet and flying at high velocity.
        rb1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
        rb3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);
    }
}
