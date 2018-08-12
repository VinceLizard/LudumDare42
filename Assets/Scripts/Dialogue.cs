using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour 
{
	[SerializeField] UITypewriterText typewriterText;
	[SerializeField] Transform dialogueStub;
	[SerializeField] float offsetDistance;
	private Transform target;
	private static Dialogue dialoguePrefab;

	public static IEnumerator Create(Vegetable target, string text, float duration)
	{
		Create(target.DialogueAnchor == null ? target.transform : target.DialogueAnchor, text, duration);
		yield return new WaitForSeconds(duration);
	}

	public static void Create(Transform target, string text, float duration)
	{
		if (dialoguePrefab == null)
			dialoguePrefab = (Resources.Load("Dialogue") as GameObject).GetComponent<Dialogue>();

		var d = GameObject.Instantiate(dialoguePrefab);
		d.typewriterText.StartTyping(text);
		d.target = target;
		GameObject.Destroy(d.gameObject, duration);
	}

	private void LateUpdate()
	{
		if (this.target != null)
		{
			var currPos = target.position;
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
