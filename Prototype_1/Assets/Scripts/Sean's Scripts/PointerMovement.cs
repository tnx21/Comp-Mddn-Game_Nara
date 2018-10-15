using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerMovement : MonoBehaviour {

    public GameObject following;    // the object this pointer is following

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        // Set the position of the camera's transform to be the same as the
        transform.position = following.transform.position;
    }
}
