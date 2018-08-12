using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedExplosion : MonoBehaviour {

    public GameObject explodingCucumber;

	// Use this for initialization
	void Start () {
        Invoke("BlowItUp", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BlowItUp()
    {
        Instantiate(explodingCucumber);
        gameObject.SetActive(false);
    }
}
