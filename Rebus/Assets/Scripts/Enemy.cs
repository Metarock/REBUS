using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
/*
hold left shift and press w,a,s,d towards, E for explosion animation, 
R for death, Z for proning and L for leaning
*/

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float dirX, dirY, moveMentSpeed = 0;
    public bool isExploding = false, isDead = false;
    bool isLeaning = false, isProning = false;
    bool facingRight = true;
    Vector3 localScale;
    public GameObject target;

    private float speed = 0.5f;

    //SANggy work
    public float enemySpeed;

    public float retreatDistance;

    public float stoppingDistance;
    public float shootingDistance;

    //introducing those bullets object into enemy class
    public WeaponSemi weaponSemi;
    public WeaponAuto weaponAuto;
    public WeaponShotgun weaponShotgun;

    public bool firePermit = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        // Console.WriteLine(target.transform.position);

        // if (Input.GetKey(KeyCode.LeftShift))
        // {
        //     hold left shifht for speed up and use a or d to move left or right
        //     moveMentSpeed = 4f;
        // }
        // else if (Input.GetKeyDown(KeyCode.E))
        // {
        //press e for testing exploding
        //     isExploded = true;
        // }

        /*   float step = speed * Time.deltaTime;
           transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);*/



        //detects if enemy have been shot by player


        movement();

        SetAnimationState();


    }

    void movement()
    {
        if (!isDead)
        {
            if (Vector2.Distance(transform.position, target.transform.position) > shootingDistance)
            {
                transform.position = this.transform.position;
                firePermit = false;
            }

            else if (Vector2.Distance(transform.position, target.transform.position) > stoppingDistance && Vector2.Distance(transform.position, target.transform.position) <= shootingDistance)
            {
                //moveTowards player && shooting
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                firePermit = true;


            }
            else if (Vector2.Distance(transform.position, target.transform.position) <= stoppingDistance && Vector2.Distance(transform.position, target.transform.position) > retreatDistance)
            {
                //stop enemy position && shooting
                transform.position = this.transform.position;
                firePermit = true;

            }
            else if (Vector2.Distance(transform.position, target.transform.position) <= retreatDistance)
            {
                //while retreating , STOP shooting
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -speed * Time.deltaTime);
                firePermit = false;

            }


            weaponSemi = FindObjectOfType<WeaponSemi>();
            weaponAuto = FindObjectOfType<WeaponAuto>();
            weaponShotgun = FindObjectOfType<WeaponShotgun>();
        }
        else
        {
            firePermit = false;
        }
        //set retreat distance to 2 ,stopping distance to 3  and shooting distance to 4

        //if beyond shooting distance, remain leaning and stop shooting



    }
    void FixedUpdate()
    {
        if (!isExploding && !isDead)
        {
            rb.velocity = new Vector2(dirX, dirY);
        }
    }
    void LateUpdate()
    {
        //CheckFace();
        ShootingAI();
    }


    void SetAnimationState()
    {
        //some may not needed or may be needed later, who knows


        if (isExploding)
        {
            anim.SetBool("isExploding", true);
        }
        else
        {
            anim.SetBool("isExploding", false);
        }


        if (firePermit)
        {
            anim.SetBool("firePermit", true);
        }
        else
        {
            anim.SetBool("firePermit", false);
        }

    }

    void CheckFace()
    {
        if (dirX > 0)
        {
            facingRight = true;
        }
        else if (dirX < 0)
        {
            facingRight = false;
        }
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;

        // Console.WriteLine(sandwallTarget.transform.position);

        // Vector3 dir = sandwallTarget.transform.position - transform.position;
        // float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void ShootingAI()
    {
        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //Debug.Log(transform.rotation);
    }
}
