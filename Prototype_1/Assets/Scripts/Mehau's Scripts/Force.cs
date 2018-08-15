using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour {
	public float radius = 10f;
	public float force = 5f;
	public ParticleSystem postShockFX;

	Rigidbody rigidbody;

	void Start () {
		
	}
	void Shockwave(){

			Vector3 pos = transform.position;
			Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

			foreach(Collider col in colliders){
			rigidbody = col.GetComponent <Rigidbody> ();
			if(rigidbody!=null){
				rigidbody.AddExplosionForce(force,pos,radius);
			}
		}
	}


	// Update is called once per frame
	void Update () {
		if(postShockFX.isPlaying){
			Shockwave();
		}
	}
}
