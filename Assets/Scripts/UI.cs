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

	private void Update()
	{
#if UNITY_EDITOR
		for (int i = 0; i <= 6; i++)
		{
			if (Input.GetKeyUp(KeyCode.Alpha0 + i) && Input.GetKey(KeyCode.LeftControl) )
			{
				Manager.currentScene = i;
				SceneManager.LoadScene(0);
				break;
			}
		}

		if ( Input.GetKeyUp(KeyCode.Plus) || Input.GetKeyUp(KeyCode.KeypadPlus) || (Input.GetKeyUp(KeyCode.Equals) && Input.GetKey(KeyCode.RightShift)))
		{
			Time.timeScale += 0.25f;
			Debug.LogWarning("Time Scale Increased! " + Time.timeScale.ToString() );
		}
		else if (Input.GetKeyUp(KeyCode.Minus) || Input.GetKeyUp(KeyCode.KeypadMinus))
		{
			Time.timeScale -= 0.25f;
			Debug.LogWarning("Time Scale Decreased! " + Time.timeScale.ToString());
		}
#endif
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
