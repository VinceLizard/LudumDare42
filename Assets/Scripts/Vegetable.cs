using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField] float walkSpeed = 6;
	[SerializeField] float turnSpeed = 180f;
	[SerializeField] float jumpTime = 1f;
    [SerializeField] float jumpDelay = 0.25f;

	[Header("Pain Points")]
	[SerializeField] List<PainPoint> painPoints;
	[SerializeField] Transform expandAnchor;
	[SerializeField] float maxSize = 3f;

	[Header("Dialogu Anchor")]
	[SerializeField] Transform dialogueAnchor;

	public Transform DialogueAnchor 
	{ 
		get 
		{
			Util.CreateIfNull(ref this.dialogueAnchor, this.transform);
			return this.dialogueAnchor; 
		} 
	}

	[Header("Animation")]
    [SerializeField] Animator animator;

	public IEnumerator WalkTo(Transform dest, bool reverse = false)
	{
		yield return MoveTo(dest.position);

		yield return TurnTo(dest.rotation, reverse);
	}

	private IEnumerator MoveTo(Vector3 dest)
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
				this.transform.forward = Vector3.RotateTowards(this.transform.forward, (dest - currPos).normalized, Mathf.Deg2Rad * turnSpeed * Time.deltaTime, 100f);
				yield return null;
			}
		}
	}

	public IEnumerator TurnTo(Quaternion dest, bool reverse = false)
	{
		dest = ProcessQuat(dest, reverse);

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

	private Quaternion ProcessQuat(Quaternion quaternion, bool reverse)
	{
		if (reverse)
			return quaternion * Quaternion.Euler(new Vector3(0, 180, 0));
		else
			return quaternion;
	}

	public IEnumerator JumpTo(Transform dest, bool reverse = false)
	{
        this.animator.SetBool("isJumping", true);
		var startPos = this.transform.position;
		var startRot = this.transform.rotation;

        yield return new WaitForSeconds(jumpDelay);
		float startTime = Time.time;

		while (true)
		{
			float timePassed = Time.time - startTime;
			if (timePassed >= jumpTime)
			{
				this.transform.position = dest.position;
				this.transform.rotation = ProcessQuat(dest.rotation, reverse);
				break;
			}
			else
			{
				float lerp = timePassed / jumpTime;
				this.transform.position = Vector3.Lerp(startPos, dest.position, lerp) + new Vector3(0, Mathf.Sin(lerp * Mathf.PI), 0);
				this.transform.rotation = Quaternion.Slerp(startRot, ProcessQuat(dest.rotation, reverse), lerp);
				yield return null;
			}
		}
    this.animator.SetBool("isJumping", false);
    }

	private bool isExpanding = false;
	private float _expandAmount = 0;
	private float expandAmount
	{
		get
		{
			return _expandAmount;
		}
		set
		{
			if ( !Mathf.Approximately(_expandAmount, value) )
			{
				_expandAmount = value;
				expandAnchor.localScale = Vector3.one * Mathf.Lerp(1f, maxSize, _expandAmount);
			}
		}
	}

	public IEnumerator WaitTillShrunk()
	{
		while(isExpanding)
		{
			yield return null;
		}
	}

	public IEnumerator Expand(float duration, List<int> painPointIndices)
	{
		foreach(var i in painPointIndices)
		{
			painPoints[i].AddPain();
		}
		isExpanding = true;
		float startTime = Time.time;
		while(true)
		{
			float timePassed = (Time.time - startTime);
			if (!isExpanding)
			{
				break;
			}
			else if( timePassed >= duration )
			{
				Main.Singleton.GameOver();
				break;
			}
			else
			{
				expandAmount = timePassed / duration;

			}
			yield return null;
		}
	}

	private void Update()
	{
		CheckShrinkage();

		if(!isExpanding)
		{
			expandAmount = Mathf.MoveTowards(expandAmount, 0f, Time.deltaTime);
		}
	}

	void CheckShrinkage()
	{
		if (isExpanding)
		{
			foreach (var pp in this.painPoints)
			{
				if (pp.PainAmount > 0)
				{
					return;
				}
			}

			isExpanding = false;
		}
	}

}
