using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientToVelocity : MonoBehaviour {

	private bool _rotate = true;
	private Rigidbody rb;
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (_rotate)
			transform.rotation = Quaternion.LookRotation(rb.velocity);
	}

	void OnCollisionEnter(Collision other)
	{
		_rotate = false;
	}
}
