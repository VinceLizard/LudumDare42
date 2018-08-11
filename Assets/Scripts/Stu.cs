using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stu : MonoBehaviour 
{
	[SerializeField] Transform cameraAnchor;
	[SerializeField] Transform launcherAnchor;
	private void Awake()
	{
		var t = Camera.main.transform;
		t.SetParent(cameraAnchor,false);
		t.localPosition = Vector3.zero;

		launcherAnchor.SetParent(t, false);
	}
}
