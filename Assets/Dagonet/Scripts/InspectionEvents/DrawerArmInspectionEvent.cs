using UnityEngine;
using System.Collections;

public class DrawerArmInspectionEvent : InspectionEvent
{
	[SerializeField]
	private AudioClip[] inspectionLines;
	[SerializeField]
	private string[] linesForSubtitles;
	[SerializeField]
	private PlaceParts puzzle2;
	
	public override IEnumerator inspectionEvents()
	{
		if(puzzle2.isDetectiveFound())
		{
			if (!GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().isPlaying)
			{
				GameObject.Find(CSM.currentCamera).GetComponent<MoveAround>().shouldTalkMediumProcess(true);
				playerAnimator.GetComponent<NavMeshAgent>().ResetPath();
				
				GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().PlayOneShot(inspectionLines[1]);
				subtitleManager.updateSubtitles(linesForSubtitles[1]);
				StartCoroutine(waitAndResetSubtitles(inspectionLines[1].length));
			}

			//Add to inventory
			puzzle2.getInventoryManager().addToInventory("detectiveItem4");
			//Add to puzzle 2 completion
			puzzle2.addToCompletion();
			//Refresh the target
			puzzle2.getPiece("Arm").GetComponent<Target>().resetItemTextCursorAndHint();
			//Delete arm
			Destroy(puzzle2.getPiece("Arm").gameObject);
		}
		else
		{
			if (!GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().isPlaying)
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