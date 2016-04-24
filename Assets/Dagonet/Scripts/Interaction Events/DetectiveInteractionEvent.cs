using UnityEngine;
using System.Collections;

public class DetectiveInteractionEvent : InteractionEvent 
{
	public AudioClip[] introLines;
	public string[] introSubtitles;
	public DialogueManager dialogueManager;

	public override IEnumerator interactionEvents()
	{
		if (!dialogueManager.detectiveCompleted && !GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().isPlaying)
		{
			GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = false;
			GameObject.Find ("CutsceneCameraDetective").GetComponent<Camera> ().enabled = true;

			speak (introLines[0], introSubtitles[0]);

			yield return new WaitForSeconds(introLines[0].length + 0.3f);

			speak (introLines[1], introSubtitles[1]);

			yield return new WaitForSeconds(introLines[1].length + 0.3f);

			speak (introLines[2], introSubtitles[2]);
			
			yield return new WaitForSeconds(introLines[2].length + 0.3f);

			//Choice starts here
			dialogueManager.choiceTwoSetup ("I was hooked up to a terminal", "[LIE] I have never been here, \njust a passerby");

			dialogueManager.setCurrentChoiceID(0);
			
			yield return new WaitForSeconds(introLines[0].length + 0.3f);
		}

		yield return new WaitForSeconds (0.0f);
	}

	public void speak(AudioClip par1Clip, string par2Subtitle)
	{
		GameObject.Find ("CharacterAnimationManager").GetComponent<CharacterAnimationManager> ().makeDetectiveTalk ();
		GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().PlayOneShot(par1Clip);
		subtitleManager.updateSubtitles(par2Subtitle, "Detective");
		StartCoroutine(waitAndResetSubtitles(par1Clip.length));
	}
}
