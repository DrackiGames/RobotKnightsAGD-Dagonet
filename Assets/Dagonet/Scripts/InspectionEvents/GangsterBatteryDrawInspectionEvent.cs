using UnityEngine;
using System.Collections;

public class GangsterBatteryDrawInspectionEvent : InspectionEvent 
{
	[SerializeField]
	private AudioClip[] inspectionLines;
	[SerializeField]
	private string[] linesForSubtitles;
	[SerializeField]
	private DialogueManager dialogueManager;
	[SerializeField]
	private InventoryManager inventoryManager;
	[SerializeField]
	private QuestTextManager questTextManager;

	private bool batteryTaken = false;

	public override IEnumerator inspectionEvents()
	{
		if(!batteryTaken && dialogueManager.gangsterCompleted && !inventoryManager.hasGotItem("battery1"))
		{
			if (!GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().isPlaying)
			{
				GameObject.Find(CSM.currentCamera).GetComponent<MoveAround>().shouldTalkMediumProcess(true);
				playerAnimator.GetComponent<NavMeshAgent>().ResetPath();
				
				GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().PlayOneShot(inspectionLines[0]);
				subtitleManager.updateSubtitles(linesForSubtitles[0]);
				StartCoroutine(waitAndResetSubtitles(inspectionLines[0].length));

				inventoryManager.addToInventory("batteryItem1");
				batteryTaken = true;
			}
		}
		
		yield return new WaitForSeconds(0.0f);
	}

	private IEnumerator batteryHintProcess()
	{
		yield return new WaitForSeconds (2.0f);

		questTextManager.popUpQuest ("YOU FOUND THE GANGSTER'S HIDDEN BATTERY!");
	}
}
