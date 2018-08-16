using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedMovement : MonoBehaviour
{

    public LayerMask groundLayer;   // for checking if player hits the ground

    Rigidbody rigbody;          // this body is used to apply directional force 

    // basic movement controls
    int maxVelocity = 10;        // max speed of the object
    int moveForce = 150;         // strength of push used for movement

    // jumping movement controls
    float jumpForce = 1000;       // strength of push used for jumping
    bool jumping = false;       // has the object used jump
    bool doubleJumping = false; // has the object used double jump

    // dash movement controls
    float lastA = -3;
    float lastD = -3;
    bool dash = false;

    // Checks if the player touches a platform and resets jumping capability if they do
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            jumping = false;
            doubleJumping = false;
        }
    }

    // Use this for initialization
    void Start()
    {
        rigbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // jumping movement
        if (Input.GetKeyDown(KeyCode.Space) && (!jumping || !doubleJumping))
        {
            //rigbody.velocity = 0;
            
            if (!jumping)
            {
                rigbody.AddForce(0, jumpForce, 0);
                jumping = true;
            }
            else
            {
                rigbody.AddForce(0, jumpForce*1.5f, 0);
                doubleJumping = true;
            }
        }
        // ground pound movement
        if (Input.GetKey("s") && (jumping || doubleJumping))
        {
            rigbody.velocity.Set(0, 0, 0);
            rigbody.AddForce(0, -jumpForce/2, 0);
        }
        // right movement
        if (Input.GetKey("d") && rigbody.velocity[0] < maxVelocity)
        {
            rigbody.AddForce(moveForce, 0, 0);
        }
        // right dash
        if (Input.GetKeyDown("d"))
        {
            if (CheckTime(lastD) < 0.5)
            {
                rigbody.AddForce(jumpForce*2, 0, 0);
            }
            else
            {
                lastD = Time.time;
            }
        }
        // left movement
        if (Input.GetKey("a") && rigbody.velocity[0] > -maxVelocity)
        {
            rigbody.AddForce(-moveForce, 0, 0);
        }
        // left dash
        if (Input.GetKeyDown("a"))
        {
            if (CheckTime(lastA) < 0.5)
            {
                rigbody.AddForce(-jumpForce*2, 0, 0);
            }
            else
            {
                lastA = Time.time;
            }
        }
    }

    float CheckTime(float i) {
        return Time.time - i;
    }
}
