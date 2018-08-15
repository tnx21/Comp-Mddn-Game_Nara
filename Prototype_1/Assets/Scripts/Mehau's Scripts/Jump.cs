using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	[Range(1, 20)]
	public float jumpVelocity;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown ("Jump")){
			GetComponent <Rigidbody> ().velocity = Vector3.up * jumpVelocity;
		}
	}
}
