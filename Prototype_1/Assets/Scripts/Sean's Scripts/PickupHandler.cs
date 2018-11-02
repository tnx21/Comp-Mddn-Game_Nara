using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour

/*
 * 
 * Script to handle player collisions with pick up objects, seperated from movement code for 
 * consistency in naming conventions.
 * 
 * In this script, a reference to the players movement script must be made to enact the powerup 
 * changes.
 * 
 * 
 * 
 * This script checks for trigger collisions, and in the case that the tag matches that of a 
 * pickup (in this case, "DoubleJump", "Dash", and "GroundSlam") then this script fires the 
 * associated method in the AdvancedMovement.cs script, passing the pickup tag with it. 
 * 
 * This method toggles the associated skill boolean in the AdvancedMovement.cs script, enabling 
 * the player to access a new moveset.
 * 
 * This script also deactivates the pickup object on collision, and plays a sound so signal 
 * that the pickup has been acquired.
 * 
 * The reason that the pickup functions as a toggle rather than a setBoolean(true) is that 
 * there may be a situation in extending this game where developers may wish to strip access 
 * to abilities from the player.
 * 
 */

{

    AdvancedMovement playerMovement;

    // Use this for initialization
    void Start()
    {
        playerMovement = GetComponent<AdvancedMovement>();
    }

    void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        switch (tag)
        {
            case "DoubleJump":

                playerMovement.toggleSkill(tag);
                FindObjectOfType<AudioManager>().Play("collectable");
                other.gameObject.SetActive(false);
                break;
            case "Dash":

                playerMovement.toggleSkill(tag);
                FindObjectOfType<AudioManager>().Play("collectable");
                other.gameObject.SetActive(false);
                break;
            case "GroundSlam":

                playerMovement.toggleSkill(tag);
                FindObjectOfType<AudioManager>().Play("collectable");
                other.gameObject.SetActive(false);
                break;
            default:


                break;
        }
    }
}
