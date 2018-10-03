using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	public GameObject debrisPrefab;

	void OnMouseDown(){
		DestroyMe();	
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.impactForceSum.magnitude > 30f){
			DestroyMe();
            FindObjectOfType<AudioManager>().Play("Rock_Breaking");
        }
	}
	void DestroyMe(){
		if(debrisPrefab){	
			Instantiate (debrisPrefab, transform.position, transform.rotation);
		}
		
		Destroy(gameObject);
	}
}
