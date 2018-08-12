using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtThis : MonoBehaviour {

    public bool isLooking;
    public GameObject lookTarget;
    public GameObject[] eyesAndLids = new GameObject[2];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        foreach(GameObject looker in eyesAndLids){
            if (isLooking) {
                var lookDir = lookTarget.transform.position - looker.gameObject.transform.position;
                looker.gameObject.transform.rotation = Quaternion.LookRotation(lookDir);
            }
        }
	}
}
