using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour 
{
	[SerializeField] float walkSpeed = 6;
	[SerializeField] float turnSpeed = 180f;
	[SerializeField] float jumpTime = 1f;


	public IEnumerator WalkTo(Transform dest)
	{
		yield return WalkTo(dest.position);

		yield return TurnTo(dest.rotation);
	}

	public IEnumerator WalkTo(Vector3 dest)
	{
		while (true)
		{
			var currPos = this.transform.position;
			if (Vector3.Distance(currPos, dest) < Mathf.Epsilon)
			{
				break;
			}
			else
			{
				this.transform.position = Vector3.MoveTowards(currPos, dest, Time.deltaTime * walkSpeed);
				yield return null;
			}
		}
	}

	public IEnumerator TurnTo(Quaternion dest)
	{
		while (true)
		{
			var currRot = this.transform.rotation;

			if (Quaternion.Angle(currRot, dest) < Mathf.Epsilon)
			{
				break;
			}
			else
			{
				this.transform.rotation = Quaternion.RotateTowards(currRot, dest, Time.deltaTime * turnSpeed);
				yield return null;
			}
		}
	}


	public IEnumerator JumpTo(Transform dest)
	{
		var startPos = this.transform.position;
		var startRot = this.transform.rotation;
		float startTime = Time.time;

		while (true)
		{
			float timePassed = Time.time - startTime;
			if (timePassed >= jumpTime)
			{
				this.transform.position = dest.position;
				this.transform.rotation = dest.rotation;
				break;
			}
			else
			{
				float lerp = timePassed / jumpTime;
				this.transform.position = Vector3.Lerp(startPos, dest.position, lerp) + new Vector3(0, Mathf.Sin(lerp * Mathf.PI), 0);
				this.transform.rotation = Quaternion.Slerp(startRot, dest.rotation, lerp);
				yield return null;
			}
		}
	}
}
