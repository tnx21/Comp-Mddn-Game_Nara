using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dash : MonoBehaviour {
	
	public float dashDist = 2.5f;

	
	void Update () {
		
		//if(Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.W)){
			
			//transform.Translate(Vector3.forward * dashDist);
		//}
		if(Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.A)){
			
			transform.Translate(-Vector3.right * dashDist);
		//}	
		//if(Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.S)){
			
			//transform.Translate(-Vector3.forward * dashDist);
		}
		if(Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.D)){
			
			transform.Translate(Vector3.right * dashDist);
		}
		
	}
}

