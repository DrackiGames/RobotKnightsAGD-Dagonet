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
	private DetectiveBodyInteractionEvent detectiveBodyEvent;
	[SerializeField]
	private Transform[] detectives;
	[SerializeField]
	private Transform[] realFixPieces;
	
	private bool detectiveFound;
	private int completion;
	private bool detectiveGotUp;

	public bool inUse;

	void Start () 
	{
		detectiveFound = false;
		completion = 0;
		detectiveGotUp = false;
		inUse = false;
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
				detectives[0].gameObject.SetActive(false);
				detectives[1].gameObject.SetActive(true);
			}
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
}
