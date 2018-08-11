using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour 
{
	[SerializeField] Rigidbody launchPrefab;
	[SerializeField] Transform launchFrom;
	[SerializeField] float launchForce;
	[SerializeField] float launchMaxTime;

	void Update () {
		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
		{
			var rb = GameObject.Instantiate(launchPrefab, launchFrom.position, launchFrom.rotation);
			rb.AddForce(rb.transform.forward * launchForce, ForceMode.Impulse);// = launchFrom.forward * launchSpeed;
			GameObject.Destroy(rb.gameObject, launchMaxTime);
		}
	}
}
