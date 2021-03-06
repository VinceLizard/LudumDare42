﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stu : MonoBehaviour 
{
	public static Stu Singleton;

	[SerializeField] Transform cameraAnchor;
	[SerializeField] Transform launcherAnchor;

	public Transform LookTarget { get; private set; }

	private void Awake()
	{
		Singleton = this;

		var t = Camera.main.transform;
		t.SetParent(cameraAnchor,false);
		t.localPosition = Vector3.zero;

		launcherAnchor.SetParent(t, false);

		LookTarget = t;

	}

	void OnDestroy()
	{
		Singleton = null;
	}

	public void ToggleThrowing(bool b)
	{
		UI.Singleton.forceSlider.gameObject.SetActive(b);
		this.launcherAnchor.gameObject.SetActive(b);
	}
}
