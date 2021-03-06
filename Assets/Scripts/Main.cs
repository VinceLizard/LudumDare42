﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour 
{
	public static Main Singleton;

	[SerializeField] List<GameObject> createOnAwake;

	void Awake()
	{
		Singleton = this;

		foreach (var go in createOnAwake)
			GameObject.Instantiate(go);
	
	}

 	void OnDestroy()
	{
		Singleton = null;
	}

	public void GameOver()
	{
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        UI.Singleton.ShowGameOver();
	}
}
