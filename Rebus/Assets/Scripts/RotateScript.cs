using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    Vector3 mousePos;
    Vector2 direction;
    Camera cam;
    Rigidbody2D rid;
    // Start is called before the first frame update
    void Start()
    {
        rid = this.GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        cursorDirection();
    }

    void cursorDirection()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = direction;
    }

    //previous cursor 
    // mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
    // rid.transform.eulerAngles = new Vector3(0,0,Mathf.Atan2((mousePos.y-transform.position.y), (mousePos.x-transform.position.x)) * Mathf.Rad2Deg);
}
