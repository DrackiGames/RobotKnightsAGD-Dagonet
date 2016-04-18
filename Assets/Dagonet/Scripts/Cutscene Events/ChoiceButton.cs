using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ChoiceButton : MonoBehaviour
{
	private Vector3 startingScale;

	[SerializeField]
	private CursorManager cursorManager;
	[SerializeField]
	private DialogueManager dialogueManager;
	[SerializeField]
	private int buttonID;

	void Start()
	{
		startingScale = transform.localScale;
	}

	void OnMouseEnter()
	{
		Debug.Log ("BUTTON TEST");
	}

	public void highlightChoiceButton()
	{
		transform.localScale = startingScale * 1.1f;
		cursorManager.highlight ();
	}

	public void shrinkButton()
	{
		transform.localScale = startingScale;
		cursorManager.normal ();
	}

	public void click()
	{
		dialogueManager.setChoiceSelected(buttonID);
		dialogueManager.choiceProcess ();
	}
}
