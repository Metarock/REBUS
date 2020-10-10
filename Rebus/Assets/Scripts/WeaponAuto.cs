using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponAuto : MonoBehaviour
{
    private AudioManager audioManager;

    public GameObject autoBullet;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 70f;
    // Cooldown per shot
    private bool cooldown = false;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (cooldown == false)
        {
            if (Input.GetButton("Fire1"))
            {
                audioManager.uziShot.Play();
                Shoot();
                // This prevents the player from spamming the automatic gun. Shoots every 0.03 seconds.
                Invoke(nameof(ResetCooldown), 0.03f);
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
        autoBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = autoBullet.GetComponent<Rigidbody2D>();
        // Creating bullet and flying at high velocity.
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
