using UnityEngine;
using System.Collections;

public class GateTerminal : MonoBehaviour 
{
	[SerializeField]
	private Gate[] mainGates;
	[SerializeField]
	private Transform[] batteries;
	[SerializeField]
	private Transform screen;
	[SerializeField]
	private Light screenLight;
	[SerializeField]
	private QuestTextManager questTextManager;
	[SerializeField]
	private DialogueManager dialogueManager;
	[SerializeField]
	private InventoryManager inventoryManager;

	private bool completed;

	public bool inUse;

	public bool foundGateTerminal;
	public bool findBatteriesHintDone;
	public bool gangsterGotBatteryHintDone;
	public bool gangsterDismissedHintDone;
	public bool leaderGotBatteryHintDone;
	public bool gateTerminalCompletedHintDone;

	void Start () 
	{
		completed = false;
		inUse = false;
		foundGateTerminal = false;
		findBatteriesHintDone = false;
		gangsterGotBatteryHintDone = false;
		gangsterDismissedHintDone = false;
		leaderGotBatteryHintDone = false;
		gateTerminalCompletedHintDone = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!completed && (batteries[0].gameObject.activeSelf || batteries[1].gameObject.activeSelf))
		{
			screen.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.5f, 0.0f);
			screenLight.color = new Color(1.0f, 0.5f, 0.0f);
		}
		if(!completed && batteries[0].gameObject.activeSelf && batteries[1].gameObject.activeSelf)
		{
			completed = true;
			screen.GetComponent<MeshRenderer>().material.color = Color.green;
			screenLight.color = Color.green;
			openGates();
		}
		if(inUse)
		{
			GetComponent<Target>().resetItemTextCursorAndHint();
		}
		if(foundGateTerminal && !findBatteriesHintDone)
		{
			findBatteriesHintDone = true;
			StartCoroutine(findBatteriesHintProcess());
		}
		if(dialogueManager.gangsterCompleted && inventoryManager.hasGotItem("batteryItem1") && !gangsterGotBatteryHintDone)
		{
			gangsterGotBatteryHintDone = true;
			StartCoroutine(gangsterGotBatteryProcess());
		}
		if(dialogueManager.gangsterCompleted && !inventoryManager.hasGotItem("batteryItem1") && !gangsterDismissedHintDone)
		{
			gangsterDismissedHintDone = true;
			StartCoroutine(gangsterDismissedProcess());
		}
		if(dialogueManager.leaderCompleted && !leaderGotBatteryHintDone)
		{
			leaderGotBatteryHintDone = true;
			StartCoroutine(leaderGotBatteryProcess());
		}
		if(completed && !gateTerminalCompletedHintDone)
		{
			gateTerminalCompletedHintDone = true;
			StartCoroutine(gateTerminalCompletedProcess());
		}
	}

	public void openGates()
	{
		foreach(Gate gate in mainGates)
		{
			gate.shouldGateOpen();
		}
	}

	public bool isCompleted()
	{
		return completed;
	}

	private IEnumerator findBatteriesHintProcess()
	{
		yield return new WaitForSeconds(1.5f);

		questTextManager.popUpQuest ("GET THE TWO MISSING BATTERIES AND FIX IT");
	}

	private IEnumerator gangsterGotBatteryProcess()
	{
		yield return new WaitForSeconds(1.5f);
		
		questTextManager.popUpQuest ("YOU PERSUADED HIM TO GIVE IT TO YOU!");
	}

	private IEnumerator gangsterDismissedProcess()
	{
		yield return new WaitForSeconds(1.5f);
		
		questTextManager.popUpQuest ("YOU FAILED TO PERSUADE HIM - USE YOUR VISOR TO FIND IT IN HIS ROOM");
	}

	private IEnumerator leaderGotBatteryProcess()
	{
		yield return new WaitForSeconds(1.5f);
		
		questTextManager.popUpQuest ("THE LEADER GAVE YOU THE BATTERY!");
	}

	private IEnumerator gateTerminalCompletedProcess()
	{
		yield return new WaitForSeconds(1.5f);
		
		questTextManager.popUpQuest ("YOU'VE OPENED THE GATE! WALK THROUGH TO END THE MINISODE :)");
	}
}
