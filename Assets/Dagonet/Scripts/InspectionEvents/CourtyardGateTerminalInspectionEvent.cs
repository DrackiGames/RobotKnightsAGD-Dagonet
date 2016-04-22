using UnityEngine;
using System.Collections;

public class CourtyardGateTerminalInspectionEvent : InspectionEvent
{
	[SerializeField]
	private AudioClip[] inspectionLines;
	[SerializeField]
	private string[] linesForSubtitles;
	[SerializeField]
	private InventoryManager inventoryManager;
	
	public override IEnumerator inspectionEvents()
	{
		if (inventoryManager.hasGotItem("batteryItem1") && inventoryManager.hasGotItem("batteryItem2"))
		{
			if(!GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().isPlaying)
			{
				GameObject.Find(CSM.currentCamera).GetComponent<MoveAround>().shouldTalkMediumProcess(true);
				playerAnimator.GetComponent<NavMeshAgent>().ResetPath();
				
				GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().PlayOneShot(inspectionLines[1]);
				subtitleManager.updateSubtitles(linesForSubtitles[1]);
				StartCoroutine(waitAndResetSubtitles(inspectionLines[1].length));
			}
		}
		else
		{
			if(!GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().isPlaying)
			{
				GameObject.Find(CSM.currentCamera).GetComponent<MoveAround>().shouldTalkMediumProcess(true);
				playerAnimator.GetComponent<NavMeshAgent>().ResetPath();
				
				GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().PlayOneShot(inspectionLines[0]);
				subtitleManager.updateSubtitles(linesForSubtitles[0]);
				StartCoroutine(waitAndResetSubtitles(inspectionLines[0].length));
			}
		}
		
		yield return new WaitForSeconds(0.0f);
	}
}
