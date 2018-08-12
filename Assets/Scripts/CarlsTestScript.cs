using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarlsTestScript : MonoBehaviour {

	[SerializeField] Transform target;

	void Start () {
		Dialogue.Create(target, "Hello World!", 10000f);		
	}

}
