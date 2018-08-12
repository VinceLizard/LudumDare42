using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Text;

public class UITypewriterText : MonoBehaviour
{
	public float displayIntervalSecs = 0.1f;
	public int charsPerDisplay = 1;
	public bool useWordBounds = false;
	public float pauseDelaySecs = 0.5f;
	public TMPro.TMP_Text label;
	public char pauseCharacter = '~';

	//[SerializeField] private bool completeOnTouch;

	public bool IsComplete { get; private set; }
	void Awake()
	{
		/*if (this.completeOnTouch)
		{
			this.gameObject.AddComponent<EventTrigger>().AddListener(EventTriggerType.PointerClick, (data) => {
				CompleteTyping();
			});
		}*/
	}


	private char[] dialogueArray;
	private string _dialogue = null;

	const string DIALOGUE_HIDER_START = "<color=#0000>";
	const string DIALOGUE_HIDER_END = "</color>";

	private string dialogue
	{
		get
		{
			return _dialogue;
		}
		set
		{
			if(this._dialogue != value && value != null)
			{
				this._dialogue = value;
				dialogueArray = new char[this._dialogue.Length + DIALOGUE_HIDER_START.Length + DIALOGUE_HIDER_END.Length];

			}
		}
	}
	private Queue<int> pauses = new Queue<int>();

	private void SetDialogue(string txt)
	{
		StringBuilder sb = new StringBuilder();
		this.pauses.Clear();
		foreach (var c in txt)
		{
			if (c != this.pauseCharacter)
				sb.Append(c);
			else
				this.pauses.Enqueue(sb.Length - 1);
		}
		this.dialogue = sb.ToString();
	}

	public void StartTyping(string txt)
	{
		IsComplete = false;
		SetDialogue(txt);
		StopAllCoroutines();
		StartCoroutine(TypeDialogueCoro());
	}

	public void SetText(string txt)
	{
		SetDialogue(txt);
		CompleteTyping();
	}

	public void CompleteTyping()
	{
		StopAllCoroutines();
		this.label.text = this.dialogue;
		IsComplete = true;
	}

	// Update is called once per frame
	IEnumerator TypeDialogueCoro()
	{
		//System.Text.StringBuilder sb = new System.Text.StringBuilder();

		/*float timeSpent = 0f;
		int dialogIndex = 0;
		while(dialogue < dialogue.Length)
		{
			timeSpent += Time.deltaTime;
			yield return null;

			float interval = (1/charsPerSecond);
			while(timeSpent > interval)
			{
				timeSpent -= interval;
			}


		}*/

		int buf = 0;
		for (int i = 0; i < dialogue.Length; i++)
		{
			if (pauses.Count > 0 && pauses.Peek() == i)
			{
				ShowDialogue(i);
				buf = 0;
				while (pauses.Count > 0 && pauses.Peek() == i)
				{
					pauses.Dequeue();
					yield return new WaitForSeconds(this.pauseDelaySecs);
				}
			}
			else
			{
				//sb.Append( dialogue[i] );
				buf++;
				if ((useWordBounds ? char.IsWhiteSpace(dialogue[i]) : buf >= charsPerDisplay) || (dialogue.Length - 1) == i)
				{
					buf = 0;
					ShowDialogue(i);
					yield return new WaitForSeconds(this.displayIntervalSecs);
				}
			}
		}
		IsComplete = true;
	}

	void ShowDialogue(int endIndex)
	{
		string txt = this.dialogue;



		if (endIndex < this.dialogue.Length - 1)
		{
			int len = endIndex + 1;
			int idx = 0;
			this.dialogue.CopyTo(0, dialogueArray, idx, len);

			idx += len;
			len = DIALOGUE_HIDER_START.Length;
			DIALOGUE_HIDER_START.CopyTo(0, dialogueArray, idx, len);

			idx += len;
			len = this.dialogue.Length - (endIndex + 1);
			this.dialogue.CopyTo(endIndex + 1, dialogueArray, idx, len);

			idx += len;
			len = DIALOGUE_HIDER_END.Length;
			DIALOGUE_HIDER_END.CopyTo(0, dialogueArray, idx, len);

			idx += len;
			this.label.SetCharArray(this.dialogueArray, 0, idx);
		}
		else
		{
			this.label.text = this.dialogue;
		}
	}

}
