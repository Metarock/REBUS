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
    public Enemy enemy ;


    void Update()
    {
        enemy = FindObjectOfType<Enemy>();
        //Debug.Log(enemy.GetComponent<Enemy>().firePermit);

        //Debug.Log(enemy.firePermit + "enemy permit????");
        if (cooldown == false && enemy.GetComponent<Enemy>().firePermit == true)
        {

            Shoot();
            // This prevents the player from spamming the semi-automatic gun. Shoots every 1.4 seconds.
            Invoke(nameof(ResetCooldown), 1.4f);
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