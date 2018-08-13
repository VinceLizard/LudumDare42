using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidColor : MonoBehaviour {

    public GameObject[] lids = new GameObject[2];
    public Material lidColor;

    private void Start () {
        foreach (GameObject lid in lids) {
        lid.GetComponent<Renderer>().material = lidColor;
        }
    }
}
