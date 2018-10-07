using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafRandomiser : MonoBehaviour {

	Material m_Material;

	Color c;

	// Use this for initialization
	void Start () {
		m_Material = GetComponent<Renderer>().material;

		float r = Random.Range(10,40)/255f;
		float g = Random.Range(65,155)/255f;
		float b = Random.Range(10,40)/255f;

		c = new Color(r,g,b);

		m_Material.color = c;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
