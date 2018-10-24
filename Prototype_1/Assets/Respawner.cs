using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour {

    public GameObject mainSpawn;
    public GameObject subSpawn;

    public int lives;
    private int lives_n;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        lives_n = lives;
    }
	
	// Update is called once per frame
	void Update () {
		
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
            lives--;
            Debug.Log("Lives: " + lives);
            if(lives > 0){
                transform.position = subSpawn.transform.position;
            }else{
                transform.position = mainSpawn.transform.position;
                lives = lives_n;
                subSpawn = mainSpawn;
            }
        }
    }
}
