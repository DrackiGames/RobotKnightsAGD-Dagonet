using UnityEngine;
using System.Collections;

public class CorridorOfficeDoorInspectionEvent : InspectionEvent
{
	[SerializeField]
	private AudioClip[] inspectionLines;
	[SerializeField]
	private string[] linesForSubtitles;
	[SerializeField]
	private DamageFloor floor;
	
	public override IEnumerator inspectionEvents()
	{
		if(floor.fallFinished)
		{
			if (!GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().isPlaying)
			{
				GameObject.Find(CSM.currentCamera).GetComponent<MoveAround>().shouldTalkMediumProcess(true);
				playerAnimator.GetComponent<NavMeshAgent>().ResetPath();
				
				GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().PlayOneShot(inspectionLines[0]);
				subtitleManager.updateSubtitles(linesForSubtitles[1]);
				StartCoroutine(waitAndResetSubtitles(inspectionLines[1].length));
			}
		}
		else
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
