using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponShotgun : MonoBehaviour
{
    private AudioManager audioManager;

    public static GameObject shotgunBullet1;
    public static GameObject shotgunBullet2;
    public static GameObject shotgunBullet3;

    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject bulletPrefab;
    // Fire Rate of the Bullet
    public float bulletForce = 50f;
    // Added cooldown per shot to prevent spamming
    private bool cooldown = false;

    Scene currentScene;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        currentScene = SceneManager.GetActiveScene();

        if (cooldown == false)
        {
            if (Input.GetButtonDown("Fire1") && currentScene.name != "MainMenu")
            {
                audioManager.shotgunShot.Play();
                Shoot();
                audioManager.shotgunReload.Play();
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
        shotgunBullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        shotgunBullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        shotgunBullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);

        Rigidbody2D rb1 = shotgunBullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = shotgunBullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = shotgunBullet3.GetComponent<Rigidbody2D>();

        // Creating bullet and flying at high velocity.
        rb1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
        rb3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);
    }
}
