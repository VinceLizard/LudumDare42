using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicBlink : MonoBehaviour {

    public float offset = 1.0f;
    public GameObject[] lids = new GameObject[2];
    public bool isBlinking = true;

	// Use this for initialization
	void Start () {
        StartCoroutine("Blink");
    }
	
	// Update is called once per frame
	IEnumerator Blink () {
        yield return new WaitForSeconds(offset);
        while(isBlinking){
            lids[0].transform.Rotate(Vector3.right *60);
            lids[1].transform.Rotate(Vector3.right *60);
            yield return new WaitForSeconds(0.1f);
            lids[0].transform.Rotate(Vector3.right * -60);
            lids[1].transform.Rotate(Vector3.right * -60);
            yield return new WaitForSeconds(8.0f);
        }
	}
}
