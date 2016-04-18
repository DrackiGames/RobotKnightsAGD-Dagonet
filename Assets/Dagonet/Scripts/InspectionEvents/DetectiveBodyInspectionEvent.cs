using UnityEngine;
using System.Collections;

public class DetectiveBodyInspectionEvent : InspectionEvent
{
	[SerializeField]
	private AudioClip[] inspectionLines;
	[SerializeField]
	private string[] linesForSubtitles;
	[SerializeField]
	private PlaceParts puzzle2;
	
	public override IEnumerator inspectionEvents()
	{
		if (!GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().isPlaying)
		{
			GameObject.Find(CSM.currentCamera).GetComponent<MoveAround>().shouldTalkMediumProcess(true);
			playerAnimator.GetComponent<NavMeshAgent>().ResetPath();
			
			GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().PlayOneShot(inspectionLines[0]);
			subtitleManager.updateSubtitles(linesForSubtitles[0]);
			StartCoroutine(waitAndResetSubtitles(inspectionLines[0].length));

			if(!puzzle2.isDetectiveFound())
			{
				puzzle2.foundDetective();
			}
		}
		
		yield return new WaitForSeconds(0.0f);
	}
}
