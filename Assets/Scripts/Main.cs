using System.Collections;
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


	public void GameOver()
	{
		UI.Singleton.ShowGameOver();
	}
}
