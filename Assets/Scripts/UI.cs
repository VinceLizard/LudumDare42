using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

	public static UI Singleton;

	public Slider forceSlider;
	public GameObject gameOverWindow;
	public Button resetGame;
    public Image sliderBackground;

	void Awake () 
	{
		Singleton = this;
		gameOverWindow.gameObject.SetActive(false);
		resetGame.onClick.AddListener(() =>
		{
			SceneManager.LoadScene(0);
		});
	}


	public void ShowGameOver()
	{
		gameOverWindow.gameObject.SetActive(true);
	}

}
