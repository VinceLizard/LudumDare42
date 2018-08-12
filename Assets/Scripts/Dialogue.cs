using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour 
{
	[SerializeField] UITypewriterText typewriterText;
	[SerializeField] Transform dialogueStub;
	[SerializeField] float offsetDistance;
	private Vegetable target;
	private static Dialogue dialoguePrefab;

	private Transform GetTarget()
	{
		return target.DialogueAnchor == null ? target.transform : target.DialogueAnchor;
	}

	public static IEnumerator Create(Vegetable target, string text, float pause = 2.5f)
	{
		if (dialoguePrefab == null)
			dialoguePrefab = (Resources.Load("Dialogue") as GameObject).GetComponent<Dialogue>();

		var d = GameObject.Instantiate(dialoguePrefab);
		d.typewriterText.StartTyping(text);
		d.target = target;


		while (!d.typewriterText.IsComplete)
			yield return null;
		
		yield return new WaitForSeconds(pause);

		GameObject.Destroy(d.gameObject);
	}

	private IEnumerator Start()
	{
		target.Face.ToggleSpeaking(true);
		while(this.typewriterText == null || !this.typewriterText.IsComplete)
		{
			yield return null;
		}
		target.Face.ToggleSpeaking(false);
	}

	private void LateUpdate()
	{
		if (this.target != null)
		{
			var currPos = GetTarget().position;
			float extraPosition;
			if ( Mathf.Abs(currPos.x) < 0.1f || currPos.x > 0)
			{
				dialogueStub.localScale = new Vector3(1, 1, 1);
				extraPosition = offsetDistance;
			}
			else
			{
				dialogueStub.localScale = new Vector3(-1, 1, 1);
				extraPosition = -offsetDistance;
			}

			var dir = Camera.main.transform.position - currPos;
			dir.y = 0f;
			dir.Normalize();
			this.transform.forward = -1 * dir;

			this.transform.position = currPos + (extraPosition * this.transform.right);
		}
	}
}
