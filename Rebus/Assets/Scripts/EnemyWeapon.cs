using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 30f;
    // Cooldown per shot
    private bool cooldown = false;

    void Update()
    {
        if (cooldown == false)
        {				
            
                Shoot();
                // This prevents the player from spamming the semi-automatic gun. Shoots every 0.4 seconds.
                Invoke(nameof(ResetCooldown), 0.4f);
                cooldown = true;
            

        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // Creating bullet and flying at high velocity.
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}