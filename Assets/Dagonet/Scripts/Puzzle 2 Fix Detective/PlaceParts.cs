using UnityEngine;
using System.Collections;

public class PlaceParts : MonoBehaviour 
{
	[SerializeField]
	private Transform ball;

	[SerializeField]
	private Transform spine;

	[SerializeField]
	private Transform hat;

	[SerializeField]
	private Transform arm;

	[SerializeField]
	private Transform[] towers; //Hat possible places

	[SerializeField]
	private InventoryManager inventoryManager;
	[SerializeField]
	private QuestTextManager questTextManager;
	[SerializeField]
	private DialogueManager dialogueManager;

	[SerializeField]
	private DetectiveBodyInteractionEvent detectiveBodyEvent;
	[SerializeField]
	private Transform[] detectives;
	[SerializeField]
	private Transform[] realFixPieces;
	
	private bool detectiveFound;
	private int completion;
	private bool detectiveGotUp;

	public bool inUse;

	public bool hasDoneDetectiveFixHint;
	public bool hasDoneDetectiveTalkHint;
	public bool hasDoneDetectiveAfterTalkHint;

	void Start () 
	{
		detectiveFound = false;
		completion = 0;
		detectiveGotUp = false;
		inUse = false;
		hasDoneDetectiveFixHint = false;
		hasDoneDetectiveTalkHint = false;
		hasDoneDetectiveAfterTalkHint = false;
		placeHat ();
	}

	void Update () 
	{
		if(!detectiveGotUp)
		{
			int numberActive = 0;
			
			foreach(Transform pieces in realFixPieces)
			{
				if(pieces.gameObject.activeSelf)
				{
					numberActive++;
				}
			}
			
			if(numberActive == 4)
			{
				detectiveGotUp = true;
				StartCoroutine(detectiveBodyEvent.exitPuzzle2());

				foreach(Target target in detectives[0].GetComponentsInChildren<Target>())
				{
					target.resetItemTextCursorAndHint();
				}

				detectives[0].gameObject.SetActive(false);
				detectives[1].gameObject.SetActive(true);
			}
		}

		if(detectiveFound && !hasDoneDetectiveFixHint)
		{
			hasDoneDetectiveFixHint = true;
			StartCoroutine(fixHintProcess());
		}

		if(isCompleted() && !hasDoneDetectiveTalkHint)
		{
			hasDoneDetectiveTalkHint = true;
			StartCoroutine(talkHintProcess());
		}

		if(dialogueManager.detectiveCompleted && !hasDoneDetectiveAfterTalkHint)
		{
			hasDoneDetectiveAfterTalkHint = true;
			StartCoroutine(afterTalkHintProcess());
		}
	}

	public InventoryManager getInventoryManager()
	{
		return inventoryManager;
	}

	public Transform getPiece(string par1ID)
	{
		Transform piece = null;
		if(par1ID == "Hat")
		{
			piece = hat;
		}
		if(par1ID == "Spine")
		{
			piece = spine;
		}
		if(par1ID == "Arm")
		{
			piece = arm;
		}
		if(par1ID == "Ball")
		{
			piece = ball;
		}

		return piece;
	}

	public bool isCompleted()
	{
		return completion == 5;
	}

	public bool isDetectiveFound()
	{
		return detectiveFound;
	}

	public void addToCompletion()
	{
		completion++;
	}

	public void foundDetective()
	{
		detectiveFound = true;
	}

	public void placeHat()
	{
		int randTower = Random.Range (0, towers.Length);
		hat.transform.position = towers [randTower].transform.position - new Vector3(0,0.75f,0);
	}

	private IEnumerator fixHintProcess()
	{
		yield return new WaitForSeconds(2.0f);

		questTextManager.popUpQuest ("USE YOUR VISOR WHEN VIEWING THE ROBOT TO SEE WHAT NEEDS TO BE FIXED");
	}

	private IEnumerator talkHintProcess()
	{
		yield return new WaitForSeconds(2.0f);

		questTextManager.popUpQuest ("TALK TO THE DETECTIVE");
	}

	private IEnumerator afterTalkHintProcess()
	{
		yield return new WaitForSeconds(1.0f);

		questTextManager.popUpQuest ("GO TO THE COURTYARD");
	}
}
