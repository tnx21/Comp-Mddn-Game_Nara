using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedMovement : MonoBehaviour
{

    public LayerMask terrain;   // for checking if player hits the terrain

    Rigidbody rigbody;

    // basic movement controls
    [Range(0, 30)]
    public int maxVelocity = 10;
    int moveForce = 150;

    // jumping movement controls
    [Range(0f, 3000f)]
    public float jumpForce = 1000f;
    bool jumping = false;
    bool doubleJumping = false;

    // dash movement controls
    float lastA = -3;   // used for timing double tap in dash
    float lastD = -3;   // used for timing double tap in dash
    bool dashing = false;
    [Range(0f, 3000f)]
    public float dashForce = 1000f;
    [Range(0f, 5f)]
    public float dashCoolDown = 3;
    float dashTimer = -10; // when dash was used last
    float dashMulti = 2.5f; // multiplier used to multiply jumpForce in the dash movements


    //Skills
    public bool doublejump = false;
    public bool dash = false;
    public bool groundslam = false;

    //Animations
    Animator anim;

    //Wall jump
    float distToGround;

    //Ground slam
    bool isGroundSlamming = false;

    //UI
    public GameObject dashCooldownIcon;

    // Checks if the player touches a platform and resets jumping capability if they do
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == terrain)
        {
            // resets ability to jump / double jump
            if (jumping)
            {
                FindObjectOfType<AudioManager>().Play("Landing_Thud");
                jumping = false;
                doubleJumping = false;
            }
        }
    }

    void Start()
    {
        rigbody = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        UpdateAnimation();
        UpdateMovement();
        UpdateUI();
    }

    private void UpdateMovement()
    {
        // jumping movement
        if (Input.GetKeyDown(KeyCode.Space) && (!jumping || !doubleJumping))
        {
            if (!jumping)
            {
                rigbody.AddForce(0, jumpForce, 0);
                anim.SetTrigger("isJumping");
                jumping = true;
                FindObjectOfType<AudioManager>().Play("Jump_Sound");
            }
            else if (doublejump)
            {
                rigbody.AddForce(0, jumpForce * 1.25f, 0);
                anim.SetTrigger("isDoubleJumping");
                doubleJumping = true;
                FindObjectOfType<AudioManager>().Play("Jump_Sound");
            }
        }

        // ground pound movement
        if (Input.GetKey("s") && !IsGrounded() && groundslam)
        {
            rigbody.velocity.Set(0, 0, 0);      // stop directional movement
            rigbody.AddForce(0, -jumpForce / 2, 0);   // apply downwards force
            isGroundSlamming = true;
        }

        // Running movement
        //Stay still if holding down both movement keys
        if(Input.GetKey("d") && Input.GetKey("a")){
            rigbody.AddForce(0, 0, 0);
        }
        //Right movement
        else if (Input.GetKey("d") && rigbody.velocity[0] < maxVelocity)
        {
            rigbody.AddForce(moveForce, 0, 0);
        }
        //Left movement
        else if(Input.GetKey("a") && rigbody.velocity[0] > -maxVelocity){
            rigbody.AddForce(-moveForce, 0, 0);
        }

        // Dash movement 
        if ((Input.GetKeyDown("d") || Input.GetKeyDown("a")) && dash)
        {
            //If pressed double tapped move key within 0.25 seconds and dash timer is off cooldown
            if (CheckTime(lastD) < 0.25 && CheckTime(dashTimer) > dashCoolDown)
            {
                rigbody.AddForce(dashForce * Input.GetAxisRaw("Horizontal"), 0, 0);
                dashTimer = Time.time;
                dashing = true;
                anim.SetTrigger("isDashing");
            }
            else
            {
                lastD = Time.time;
            }
        }

    }

    // time difference between 2 times. Confirms user double tapped.
    private float CheckTime(float i)
    {
        return Time.time - i;
    }

    private void UpdateAnimation()
    {
        //Rotating the player in the direction they are moving
        Quaternion right = Quaternion.Euler(0f, 0f, 0f);
        Quaternion left = Quaternion.Euler(0f, 180f, 0f);
        if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            transform.rotation = Quaternion.Lerp(right, left, Time.time * 3);
        }
        else if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            transform.rotation = Quaternion.Lerp(left, right, Time.time * 3);
        }

        //Running Animation
        if (IsMoving())
        {
            anim.SetBool("isRunning", true);
        }
        else if (!IsMoving())
        {
            anim.SetBool("isRunning", false);
        }

        //Wall Jump Animation 
        //if holding down move but x positing not moving and isn't grounded, then is wall jumping
        if ((rigbody.velocity.x >= -0.5 && rigbody.velocity.x <= 0.5) && IsMoving() && !IsGrounded())
        {
            anim.SetBool("isWallJumping", true);
        }
        else
        {
            anim.SetBool("isWallJumping", false);
        }

        //Ground Slam Animation
        if (isGroundSlamming && IsGrounded())
        {
            anim.Play("Ground_Slam");
        }
        if (IsGrounded())
        {
            isGroundSlamming = false;
        }
    }

    //Activating skills with pickups
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

    //Updating UI to show cooldowns of player abilities
    private void UpdateUI()
    {
        //If dash is off cooldown and has the dash ability
        if (CheckTime(dashTimer) > dashCoolDown && dash)
        {
            dashCooldownIcon.SetActive(false);
        }
        else
        {
            dashCooldownIcon.SetActive(true);
        }
    }

    //Checking if player is moving based on key inputs
    private bool IsMoving()
    {
        if (Input.GetKey("a") && Input.GetKey("d")){
            return false;
        }
        else if (Input.GetKey("a") || Input.GetKey("d"))
        {
            return true;
        }
        return false;
    }

    private bool IsGrounded()
    {
        //Checking the distance between the player and the ground to determine if the player is grounded
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.3f);
    }
}