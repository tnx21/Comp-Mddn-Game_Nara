using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour {

    /*
     * Script to handle player collisions with pick up objects, seperated from movement code for simplicity.
     */

    AdvancedMovement playerMovement;

	// Use this for initialization
	void Start () {
        playerMovement = GetComponent<AdvancedMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        switch (tag)
        {
            case "DoubleJump":
               
                playerMovement.toggleSkill(tag);
                other.gameObject.SetActive(false);
                break;
            case "Dash":
               
                playerMovement.toggleSkill(tag);
                other.gameObject.SetActive(false);
                break;
            case "GroundSlam":
                
                playerMovement.toggleSkill(tag);
                other.gameObject.SetActive(false);
                break;
            default:

        
                break;
        }
    }
}
