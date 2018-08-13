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
	public GameObject finWindow;

	void Awake ()
	{
		Singleton = this;
		gameOverWindow.gameObject.SetActive(false);
		finWindow.SetActive(false);
		resetGame.onClick.AddListener(() =>
		{
			SceneManager.LoadScene(0);
		});
	}

	void OnDestroy()
	{
		Singleton = null;
	}

	public void ShowFinished()
	{
		finWindow.gameObject.SetActive(true);
	}

	public void ShowGameOver()
	{
		StartCoroutine(ShowGameOverCoro());
	}

	IEnumerator ShowGameOverCoro()
	{
		yield return new WaitForSeconds(4f);

		gameOverWindow.gameObject.SetActive(true);
	}
}
