using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddExplosionForce(5, transform.position, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
