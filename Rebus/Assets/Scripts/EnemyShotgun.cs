using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotgun : MonoBehaviour
{
    //variables

    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;

    public GameObject bulletPrefab;


    public float bulletForce = 10f;

    private bool cooldown = false;
    public Enemy enemy;
    // Update is called once per frame
    void Update()
    {
        enemy = FindObjectOfType<Enemy>();

        if (cooldown == false && enemy.GetComponent<Enemy>().firePermit == true)
        {
            Shoot();
            Invoke(nameof(ResetCooldown), 1.25f);
            cooldown = true;
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }

    void Shoot()
    {
        GameObject shotgunBullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        GameObject shotgunBullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        GameObject shotgunBullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);

        Rigidbody2D rb1 = shotgunBullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = shotgunBullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = shotgunBullet3.GetComponent<Rigidbody2D>();

        // Creating bullet and flying at high velocity.
        rb1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
        rb3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);
    }

}
