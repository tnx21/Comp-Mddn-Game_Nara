using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	public GameObject debrisPrefab;

	void OnMouseDown(){
		DestroyMe();	
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.impactForceSum.magnitude > 0.1f){
			DestroyMe();
		}
	}
	void DestroyMe(){
		if(debrisPrefab){	
			Instantiate (debrisPrefab, transform.position, transform.rotation);
		}
		
		Destroy(gameObject);
	}
}
