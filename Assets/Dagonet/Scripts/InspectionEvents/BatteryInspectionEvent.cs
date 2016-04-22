using UnityEngine;
using System.Collections;

public class BatteryInspectionEvent : InspectionEvent
{
	[SerializeField]
	private AudioClip[] inspectionLines;
	[SerializeField]
	private string[] linesForSubtitles;
	[SerializeField]
	private DialogueManager dialogueManager;
	[SerializeField]
	private InventoryManager inventoryManager;
	
	public override IEnumerator inspectionEvents()
	{
		if (dialogueManager.gangsterCompleted && !inventoryManager.hasGotItem("battery1") && !GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().isPlaying)
		{
			GameObject.Find(CSM.currentCamera).GetComponent<MoveAround>().shouldTalkMediumProcess(true);
			playerAnimator.GetComponent<NavMeshAgent>().ResetPath();
			
			GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().PlayOneShot(inspectionLines[0]);
			subtitleManager.updateSubtitles(linesForSubtitles[0]);
			StartCoroutine(waitAndResetSubtitles(inspectionLines[0].length));
		}
		
		yield return new WaitForSeconds(0.0f);
	}
}

