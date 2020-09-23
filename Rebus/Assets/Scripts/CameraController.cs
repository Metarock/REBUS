using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public bool followPlayer = true;
    PlayerMovement playerMovement;
    private Camera cam;

    //Camera boundary
    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private float halfHeight;
    private float halfWidth;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        cam = GetComponent<Camera>();
        cam = Camera.main;

        //camera boundaries
        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;

        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //this allows players to look ahead of the map
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            followPlayer = false;
            playerMovement.setMoving(false);
        }
        else
        {
            followPlayer = true;
        }
        if(followPlayer == true)
        {
            camFollowPlayer();
        }
        else
        {
            aheadControl();
        }

        //getting camera size and limiting it to the map vision
        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfWidth, maxBounds.y - halfHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    //set playermovement as true after going ahead
    public void setFollowPlayer(bool val)
    {
        followPlayer = val;
    }

    void camFollowPlayer()
    {
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = newPos;
    }

    void aheadControl()
    {
        //allows the camera to move
        Vector3 cameraPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        //limits the range of the player when looking ahead
        cameraPos.z = -10;

        //we get a direction to where the mouse
        Vector3 direction = cameraPos - transform.position;
        
        //this basically states if the player is visible 
        if(player.GetComponent<SpriteRenderer>().isVisible == true)
        {
            //then it will move the camera in the direction of the mouse
            transform.Translate(direction * 2 * Time.deltaTime);
        }
    }
}
