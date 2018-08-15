using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeanMovement : MonoBehaviour {

    public LayerMask groundLayer;
    Rigidbody rigbody;          // this body is used to apply directional force 
    int maxVelocity = 10;        // max speed of the object
    int moveForce = 150;         // strength of push used for movement
    int jumpForce = 800;       // strength of push used for jumping
    bool jumping = false;       // has the object used jump
    bool doubleJumping = false; // has the object used double jump

    // Checks if the player touches a platform and resets jumping capability if they do
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.layer == groundLayer) {
            jumping = false;
            doubleJumping = false;
        }
    }

    // Use this for initialization
    void Start () {
        rigbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        // jumping movement
        if (Input.GetKeyDown(KeyCode.Space) && (!jumping || !doubleJumping)) {
            //rigbody.velocity = 0;
            rigbody.AddForce(0, jumpForce, 0);
            if (!jumping) {
                jumping = true;
            } else {
                doubleJumping = true;
            }
        }
        // forward movement
        if (Input.GetKey("w") && rigbody.velocity[2] < maxVelocity) {
            rigbody.AddForce(0, 0, moveForce);
            Debug.Log(rigbody.velocity);
        }
        // backward movement
        if (Input.GetKey("s") && rigbody.velocity[2] > -maxVelocity) {
            rigbody.AddForce(0, 0, -moveForce);
            Debug.Log(rigbody.velocity);
            Debug.Log("hi");
        }
        // right movement
        if (Input.GetKey("d") && rigbody.velocity[0] < maxVelocity) {
            rigbody.AddForce(moveForce, 0, 0);
        }
        // left movement
        if (Input.GetKey("a") && rigbody.velocity[0] > -maxVelocity) {
            rigbody.AddForce(-moveForce, 0, 0);
        }
    }
}
