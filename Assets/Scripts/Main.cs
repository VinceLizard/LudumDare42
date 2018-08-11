using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour 
{
	[SerializeField] List<GameObject> createOnAwake;

	void Awake() 
	{
		foreach (var go in createOnAwake)
			GameObject.Instantiate(go);
	}

}
