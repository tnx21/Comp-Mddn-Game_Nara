using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_sound : MonoBehaviour {

	public AudioSource playSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.W)){

			//playSound.Play();
		//}
		if(Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.A)){

			playSound.Play();
		}
		//if(Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.S)){

			//playSound.Play();
		//}
		if(Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.D)){

			playSound.Play();
		}
	}
}
