using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    public Transform explosionPoint;

	// Use this for initialization
	void Start () {
        Vector3 explosionPos = explosionPoint.position;
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.AddExplosionForce(100, explosionPos, 10, 1f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
