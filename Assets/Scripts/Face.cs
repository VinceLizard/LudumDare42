using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour 
{
	[SerializeField] Animator mouthAnimator;
	[SerializeField] GameObject hurtFace;
	[SerializeField] GameObject normalFace;
	[SerializeField] LookAtThis lookAtThis;

	public void StopLooking()
	{
		this.lookAtThis.lookTarget = null;
	}

	public void LookAt(Vegetable vegetable)
	{
		LookAt(vegetable.LookTarget);
	}

	public void LookAt(Stu stu)
	{
		LookAt(stu.LookTarget);
	}

	public void LookAt(Transform target)
	{
		lookAtThis.lookTarget = target;
	}

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
