using UnityEngine;
using System.Collections;

public class LeaderInteractionEvent : InteractionEvent 
{
	public AudioClip[] introLines;
	public string[] introSubtitles;
	public DialogueManager dialogueManager;
	
	public override IEnumerator interactionEvents()
	{
		if (!dialogueManager.leaderCompleted && !GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().isPlaying)
		{
			GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = false;
			GameObject.Find ("CutsceneCameraLeader").GetComponent<Camera> ().enabled = true;
			
			speak (introLines[0], introSubtitles[0]);
			
			yield return new WaitForSeconds(introLines[0].length + 0.3f);
			
			speak (introLines[1], introSubtitles[1]);
			
			yield return new WaitForSeconds(introLines[1].length + 0.3f);
			
			speak (introLines[2], introSubtitles[2]);
			
			yield return new WaitForSeconds(introLines[2].length + 0.3f);

			speak (introLines[3], introSubtitles[3]);
			
			yield return new WaitForSeconds(introLines[3].length + 0.3f);

			speak (introLines[4], introSubtitles[4]);
			
			yield return new WaitForSeconds(introLines[4].length + 0.3f);

			speak (introLines[5], introSubtitles[5]);
			
			yield return new WaitForSeconds(introLines[5].length + 0.3f);
			
			//Choice starts here
			dialogueManager.choiceTwoSetup ("Sure you seem like \na reliable leader", "No, every robot are \nfor themselves");
			
			dialogueManager.setCurrentChoiceID(4);
			
			yield return new WaitForSeconds(introLines[0].length + 0.3f);
		}
		
		yield return new WaitForSeconds (0.0f);
	}
	
	public void speak(AudioClip par1Clip, string par2Subtitle)
	{
		GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().PlayOneShot(par1Clip);
		subtitleManager.updateSubtitles(par2Subtitle, "Leader");
		StartCoroutine(waitAndResetSubtitles(par1Clip.length));
	}
}
