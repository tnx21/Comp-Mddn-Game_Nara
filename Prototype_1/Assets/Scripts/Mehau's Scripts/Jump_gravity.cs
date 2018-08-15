using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_gravity : MonoBehaviour {

		public float fall = 5.5f;
		public float low = 4f;
		
		Rigidbody rb;

		void Awake(){
			rb = GetComponent <Rigidbody>();

		}
		void Update(){
			if (rb.velocity.y <0){
				rb.velocity += Vector3.up * Physics.gravity.y * (fall - 1) * Time.deltaTime;	
		} else if (rb.velocity.y > 0 && !Input.GetButton ("Jump")){
			rb.velocity += Vector3.up * Physics.gravity.y * (low - 1) * Time.deltaTime;
		}

	}
}
