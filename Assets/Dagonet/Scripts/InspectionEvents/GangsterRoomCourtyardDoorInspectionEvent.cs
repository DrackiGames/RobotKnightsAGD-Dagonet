using UnityEngine;
using System.Collections;

public class GangsterRoomCourtyardDoorInspectionEvent : InspectionEvent
{
	[SerializeField]
	private AudioClip[] inspectionLines;
	[SerializeField]
	private string[] linesForSubtitles;
	
	public override IEnumerator inspectionEvents()
	{
		yield return new WaitForSeconds(0.0f);
	}
}
