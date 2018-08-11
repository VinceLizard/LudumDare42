using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public static UI Singleton;

	public Slider forceSlider;

	void Awake () 
	{
		Singleton = this;
	}

}
