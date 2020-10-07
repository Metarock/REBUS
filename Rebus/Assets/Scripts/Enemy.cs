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
    bool isExploded, isDead;
    bool isLeaning, isProning;
    bool facingRight = true;
    Vector3 localScale;
    public GameObject target;

    private float speed = 0.5f;

    //SANggy work
    public float enemySpeed;
    public float stoppingDistance;
    public float retreatDistance;



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

        // Console.WriteLine(target.transform.position);

        // if (Input.GetKey(KeyCode.LeftShift))
        // {
        //     hold left shifht for speed up and use a or d to move left or right
        //     moveMentSpeed = 4f;
        // }
        // else if (Input.GetKeyDown(KeyCode.E))
        // {
        //     isExploded = true;
        // }
        // else if (Input.GetKeyDown(KeyCode.R))
        // {
        //     isDead = true;
        // }
        // else if (Input.GetKeyDown(KeyCode.Z))
        // {
        //     if (isProning)
        //     {
        //         isProning = false;
        //     }
        //     else
        //     {
        //         isProning = true;
        //     }
        // }
        // else if (Input.GetKeyDown(KeyCode.L))
        // {
        //     if (isLeaning)
        //     {
        //         isLeaning = false;
        //     }
        //     else
        //     {
        //         isLeaning = true;
        //     }
        // }
        // else
        // {
        //     moveMentSpeed = 2f;
        // }
     /*   float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);*/

        movement();
        SetAnimationState();
        // if (!isDead && !isLeaning && !isExploded && !isProning)
        // {
        //     dirX = Input.GetAxisRaw("Horizontal") * moveMentSpeed;
        //     dirY = Input.GetAxisRaw("Vertical") * moveMentSpeed;
        // }
    }

    void movement()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > stoppingDistance)
        {
            //moveTowards player
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        } 
        else if (Vector2.Distance(transform.position, target.transform.position) < stoppingDistance && Vector2.Distance(transform.position, target.transform.position) > retreatDistance)
        {
            //stop enemy position
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, target.transform.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -speed * Time.deltaTime);
        }
    }
    void FixedUpdate()
    {
        if (!isExploded)
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
        if (transform.position.x == 0 && transform.position.y == 0)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }


        else if (speed == 1f)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", true);


        }
        if (isDead)
        {
            anim.SetBool("isDead", true);
        }
        else
        {
            anim.SetBool("isDead", false);

        }
        if (isExploded)
        {
            anim.SetBool("isExploded", true);
        }
        else
        {
            anim.SetBool("isExploded", false);
        }
        if (isProning)
        {
            anim.SetBool("isProning", true);
        }
        else
        {
            anim.SetBool("isProning", false);
        }
        if (isLeaning)
        {
            anim.SetBool("isLeaning", true);
        }
        else
        {
            anim.SetBool("isLeaning", false);
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
