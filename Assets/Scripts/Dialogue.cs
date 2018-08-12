using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour 
{
	[SerializeField] UITypewriterText typewriterText;
	private Transform target;

	private static Dialogue dialoguePrefab;

	public static void Create(Vegetable target, string text, float duration)
	{
		Create(target.DialogueAnchor, text, duration);
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
		this.transform.position = target.position;
	}
}
