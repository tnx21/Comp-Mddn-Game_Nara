using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour {

    public GameObject mainSpawn;
    public GameObject subSpawn;
    public GameObject heart1, heart2, heart3, heart4, heart5;

    private int currentLives;
    private int maxLives;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        maxLives = 5;
        currentLives = maxLives;
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Mainspawn")){
            Debug.Log("Updated main spawn");
            mainSpawn = other.gameObject;
            subSpawn = other.gameObject;
        }
        if (other.CompareTag("Subspawn")){
            Debug.Log("Updated sub spawn");
            subSpawn = other.gameObject;
        }
        if(other.CompareTag("Killbox")){
            rb.velocity = new Vector3(0, 0, 0);
            currentLives--;
            Debug.Log("Lives: " + currentLives);
            if(currentLives > 0){
                transform.position = subSpawn.transform.position;
            }else{
                transform.position = mainSpawn.transform.position;
                currentLives = maxLives;
                subSpawn = mainSpawn;
            }
            UpdateHud();
        }
    }

    void UpdateHud()
    {
        if (currentLives > maxLives)
        {
            currentLives = maxLives;
        }

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
