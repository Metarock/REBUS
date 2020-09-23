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
    float dirX, dirY, moveMentSpeed = 2f;
    bool isExploded, isDead;
    bool isLeaning, isProning;
    bool facingRight = true;
    Vector3 localScale;
    public GameObject target;




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
        Console.WriteLine(target.transform.position);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //hold left shifht for speed up and use a or d to move left or right
            moveMentSpeed = 4f;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            isExploded = true;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            isDead = true;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            if (isProning)
            {
                isProning = false;
            }
            else
            {
                isProning = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            if (isLeaning)
            {
                isLeaning = false;
            }
            else
            {
                isLeaning = true;
            }
        }
        else
        {
            moveMentSpeed = 2f;
        }

        SetAnimationState();
        if (!isDead && !isLeaning && !isExploded && !isProning)
        {
            dirX = Input.GetAxisRaw("Horizontal") * moveMentSpeed;
            dirY = Input.GetAxisRaw("Vertical") * moveMentSpeed;
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
        CheckFace();
        ShootingAI();
    }

    void SetAnimationState()
    {
        if (dirX == 0 && dirY == 0)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }

        if (Mathf.Abs(dirX) == 2 || Mathf.Abs(dirY) == 2)
        {
            anim.SetBool("isWalking", true);
        }
        if (Mathf.Abs(dirX) == 4 || Mathf.Abs(dirY) == 4)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);

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

    void ShootingAI()
    {

        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
