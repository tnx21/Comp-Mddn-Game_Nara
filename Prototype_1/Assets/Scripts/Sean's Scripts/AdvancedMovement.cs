using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedMovement : MonoBehaviour
{

    public LayerMask groundLayer;   // for checking if player hits the ground

    Rigidbody rigbody;          // this body is used to apply directional force 

    // basic movement controls
    [Range(0, 30)]
    public int maxVelocity = 10;        // max speed of the object
    int moveForce = 150;         // strength of push used for movement

    // jumping movement controls
    [Range(0f, 3000f)]
    public float jumpForce = 1000f;       // strength of push used for jumping
    bool jumping = false;       // has the object used jump
    bool doubleJumping = false; // has the object used double jump

    // dash movement controls
    float lastA = -3;   // used for timing double tap in dash
    float lastD = -3;   // used for timing double tap in dash
    bool dashing = false;  // is object dashing
    [Range(0f, 3000f)]
    public float dashForce = 1000f; // strength of push used for dashing
    [Range(0f, 5f)]
    public float dashCoolDown = 3;
    float dashTimer = -10; // when dash was used last
    float dashMulti = 2.5f; // multiplier used to multiply jumpForce in the dash movements


    //Skills
    public bool doublejump = true;
    public bool dash = true;
    public bool groundslam = true;

    //wall check
    public GameObject rcPoint;

    //Animations
    Animator anim;
    bool isMoving = false;

    //Wall jump
    float oldPos;

    // Checks if the player touches a platform and resets jumping capability if they do
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            // resets ability to jump/ double jump
            if (jumping)
            {
                FindObjectOfType<AudioManager>().Play("Landing_Thud");
                jumping = false;
                doubleJumping = false;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        rigbody = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();

        movementLogic();

        wallCheck();



    }


    private void wallCheck(){
        RaycastHit hit;
        
        if(Physics.Raycast(rcPoint.transform.position, rcPoint.transform.right, out hit, 2f) && isMoving){
            Debug.Log("There is something in front of me");
            Debug.DrawRay(rcPoint.transform.position, rcPoint.transform.right, Color.green, 2f, false);

        }else{
            Debug.DrawRay(rcPoint.transform.position, rcPoint.transform.right*2, Color.red);
        }
        if (Physics.Raycast(rcPoint.transform.position, -rcPoint.transform.up, out hit, 0.2f))
        {
            Debug.DrawRay(rcPoint.transform.position, -rcPoint.transform.up, Color.green, 0.5f, false);
            Debug.Log("There is something below me");
            anim.SetTrigger("isWallJumping");
        }else{
            Debug.DrawRay(rcPoint.transform.position, -rcPoint.transform.up*0.2f, Color.red);
            anim.Play("Run");
        }
        Debug.Log("Break");
    }


    void movementLogic()
    {
        // jumping movement
        if (Input.GetKeyDown(KeyCode.Space) && (!jumping || !doubleJumping))
        {
            if (!jumping)
            {
                rigbody.AddForce(0, jumpForce, 0);
                anim.SetTrigger("isJumping");
                jumping = true;
            }
            else if (doublejump)
            {
                rigbody.AddForce(0, jumpForce * 1.25f, 0);
                anim.SetTrigger("isDoubleJumping");
                doubleJumping = true;
            }
            FindObjectOfType<AudioManager>().Play("Jump_Sound");
        }
        // ground pound movement
        if (Input.GetKey("s") && (jumping || doubleJumping) && groundslam)
        {
            rigbody.velocity.Set(0, 0, 0);      // stop directional movement
            rigbody.AddForce(0, -jumpForce / 2, 0);   // apply downwards force
        }
        // right movement
        if (Input.GetKey("d") && rigbody.velocity[0] < maxVelocity)
        {
            rigbody.AddForce(moveForce, 0, 0);
        }
        // right dash
        if (Input.GetKeyDown("d") && dash)
        {
            if (CheckTime(lastD) < 0.25 && CheckTime(dashTimer) > dashCoolDown)
            {
                rigbody.AddForce(dashForce, 0, 0);
                dashTimer = Time.time;
                dashing = true;
                anim.SetTrigger("isDashing");
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
        if (Input.GetKeyDown("a") && dash)
        {
            if (CheckTime(lastA) < 0.25 && CheckTime(dashTimer) > dashCoolDown)
            {
                rigbody.AddForce(-dashForce, 0, 0);
                dashTimer = Time.time;
                dashing = true;
                anim.SetTrigger("isDashing");
            }
            else
            {
                lastA = Time.time;
            }
        }
    }

    // time difference between 2 times. Confirms user double tapped.
    float CheckTime(float i) {
        return Time.time - i;
    }

    void UpdateAnimation()
    {

        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            isMoving = true;
        }
        if (!Input.GetKey("a") && !Input.GetKey("d"))
        {
            isMoving = false;
        }

        Quaternion right = Quaternion.Euler(0f, 0f, 0f);
        Quaternion left = Quaternion.Euler(0f, 180f, 0f);

        if (Input.GetKey("a"))
        {
            transform.rotation = Quaternion.Lerp(right, left, Time.time * 3);
        }
        else if (Input.GetKey("d"))
        {
            transform.rotation = Quaternion.Lerp(left, right, Time.time * 3);
        }

        //Running Animation
        if (isMoving)
        {
            anim.SetBool("isRunning", true);
        }
        else if (!isMoving)
        {
            anim.SetBool("isRunning", false);
        }
    }

public void toggleSkill(string s)
    {
        switch (s)
        {
            case "DoubleJump":
                doublejump = !doublejump;
                break;
            case "Dash":
                dash = !dash;
                break;
            case "GroundSlam":
                groundslam = !groundslam;
                break;
            default:
                Debug.Log("No ability found for pickup: " + s);
                break;
        }
    }
} 