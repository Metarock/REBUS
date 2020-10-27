using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAuto : MonoBehaviour
{
    //variables
    public static GameObject autoBullet;
    public Transform firepoint;
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
            shoot();
            Invoke(nameof(ResetCoolDown), 0.35f);
            cooldown = true;
        }
    }

    void ResetCoolDown()
    {
        cooldown = false;
    }

    void shoot()
    {
        autoBullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = autoBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
