using UnityEngine;
using System.Collections;

public class TutorialButton : MonoBehaviour 
{
	private Vector3 startingScale;

	[SerializeField]
	private CursorManager cursorManager;

	void Start()
	{
		startingScale = transform.localScale;
	}

	public void overTutorialButton()
	{
		transform.localScale = startingScale * 1.1f;
		cursorManager.highlight ();
	}

	public void outsideTutorialButton()
	{
		transform.localScale = startingScale;
		cursorManager.normal ();
	}

}
