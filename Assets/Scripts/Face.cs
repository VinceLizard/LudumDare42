using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour 
{
	[SerializeField] Animator mouthAnimator;
	[SerializeField] GameObject hurtFace;
	[SerializeField] GameObject normalFace;

	public void ToggleSpeaking(bool b)
	{
		mouthAnimator.SetBool("IsSpeaking", b);
	}

	public void ToggleDamage(bool b)
	{
		hurtFace.SetActive(b);
		normalFace.SetActive(!b);
	}
}
