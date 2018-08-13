using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicBlink : MonoBehaviour {
    
    public GameObject[] lids = new GameObject[2];
    public bool isBlinking = true;
    
	void Start () {
        StartCoroutine("Blink");
    }
	
	IEnumerator Blink () {
        yield return new WaitForSeconds(Random.Range(1f, 5f));
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
