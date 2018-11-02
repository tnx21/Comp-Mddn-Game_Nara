using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftBehaviour : MonoBehaviour {

    public GameObject player;
    public GameObject pointer;
    public float force, range;

    private Rigidbody rb;

	// Use this for initialization
	void Awake () {
        rb = player.GetComponent<Rigidbody>();
        Debug.Log(rb.velocity);
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float position = (player.transform.position.y - pointer.transform.position.y);
            if (position < 0) { position = 1; }
            float scale = 1f - (position / range);
            Debug.Log(scale + ":" + force);
            rb.AddForce(0.0f, scale * force, 0.0f);
        }
    }
}
