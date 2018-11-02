using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour

/*
 * 
 * This code handles the respawn mechanic for the player.
 * 
 * Respawns are handled with three main requirements in scene, there are a
 * 
 *  - mainspawn trigger collider
 *  - subspawn trigger collider
 *  - killbox trigger collider
 *  
 * There may be multiple main/sub spawns, as well as killboxes in scene.
 *  
 * The code checks for entering trigger colliders, and checks against the GameObject tag as
 * to what type of collider has entered. 
 * 
 * In the case of a "Mainspawn" tag, the mainSpawn field is updated with the colliders gameobject.
 * In the case of a "Subspawn" tag, the mainSpawn field is updated with the colliders gameobject.
 * 
 * In the case of a "Killbox" tag, the player is killed, and the HUD is updated to reflect the players remaining lives
 * 
 * If the players "currentLives" are greater than zero, the player is transported back to the last subspawn they entered
 * In the players "currentLives" are less than zero, the player is transported back to the last mainspawn they entered, and their lives are reset
 * 
 * This behaviour allows for softcore punishment loop within the gameplay
 * 
 */

{

    public GameObject mainSpawn;
    public GameObject subSpawn;
    public GameObject heart1, heart2, heart3, heart4, heart5;

    private int currentLives;
    private int maxLives;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxLives = 5;
        currentLives = maxLives;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mainspawn"))
        {
            if (other.gameObject != this.mainSpawn)
            {
                Debug.Log("Updated main spawn");
                mainSpawn = other.gameObject;
                subSpawn = other.gameObject;
                FindObjectOfType<AudioManager>().Play("checkpoint");
            }
        }
        if (other.CompareTag("Subspawn"))
        {
            if (other.gameObject != this.subSpawn)
            {
                Debug.Log("Updated sub spawn");
                subSpawn = other.gameObject;
                FindObjectOfType<AudioManager>().Play("checkpoint");
            }
        }
        if (other.CompareTag("Killbox"))
        {
            rb.velocity = new Vector3(0, 0, 0);
            currentLives--;
            Debug.Log("Lives: " + currentLives);
            if (currentLives > 0)
            {
                transform.position = subSpawn.transform.position;
            }
            else
            {
                transform.position = mainSpawn.transform.position;
                currentLives = maxLives;
                subSpawn = mainSpawn;
            }
            UpdateHud();
        }
    }

    //Update Hub to show lives when life is lost
    void UpdateHud()
    {
        if (currentLives > maxLives)
        {
            currentLives = maxLives;
        }

        //Depending on how many lives left, display the correct amount of lives
        switch (currentLives)
        {
            case 5:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(true);
                heart5.gameObject.SetActive(true);
                break;
            case 4:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(true);
                heart5.gameObject.SetActive(false);
                break;
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;
        }
    }
}
