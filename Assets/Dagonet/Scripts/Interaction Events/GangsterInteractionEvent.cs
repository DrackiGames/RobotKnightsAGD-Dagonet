using UnityEngine;
using System.Collections;

public class GangsterInteractionEvent : InteractionEvent 
{
	public AudioClip[] introLines;
	public string[] introSubtitles;
	public DialogueManager dialogueManager;
	public Transform gangsterTalkSpot;

	public override IEnumerator interactionEvents()
	{
		if(!dialogueManager.gangsterCompleted)
		{
			if (!GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().isPlaying)
			{	
				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = false;
				GameObject.Find ("CutsceneCameraGangster").GetComponent<Camera> ().enabled = true;
				
				speak (introLines[0], introSubtitles[0]);
				
				yield return new WaitForSeconds(introLines[0].length + 0.3f);
				
				speak (introLines[1], introSubtitles[1]);
				
				yield return new WaitForSeconds(introLines[1].length + 0.3f);
				
				//Choice starts here
				dialogueManager.choiceTwoSetup ("[BE AGGRESSIVE]", "[BE UNDERSTANDING]");
				
				dialogueManager.setCurrentChoiceID(2);
			}
		}
		
		yield return new WaitForSeconds (0.0f);
	}
	
	public void speak(AudioClip par1Clip, string par2Subtitle)
	{
		GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().PlayOneShot(par1Clip);
		subtitleManager.updateSubtitles(par2Subtitle, "Gangster");
		StartCoroutine(waitAndResetSubtitles(par1Clip.length));
	}
}
