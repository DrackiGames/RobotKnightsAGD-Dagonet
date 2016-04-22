using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DetectiveBodyInteractionEvent : InteractionEvent 
{
	[SerializeField]
	private PlaceParts puzzle2;

	public override IEnumerator interactionEvents()
	{
		if(!puzzle2.isCompleted())
		{
			yield return new WaitForSeconds(0.3f);
			
			CSM.isFadingIn = false;

			Debug.Log("DOES GET HERE");
			
			yield return new WaitForSeconds(0.3f);

			GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = false;
			GameObject.Find("Puzzle2FixDetectiveCamera").GetComponent<Camera>().enabled = true;
			
			puzzle2.inUse = true;
			
			yield return new WaitForSeconds(0.3f);
			
			CSM.isFadingIn = true;
			GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();
			
			yield return new WaitForSeconds(0.5f);

			GameObject.Find ("EscapeText").GetComponent<Text>().enabled = true;
			GameObject.Find ("EscapeText").GetComponent<Outline>().enabled = true;
			
			//		if (!GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().isPlaying)
			//		{
			//			GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().PlayOneShot(interactionLines[0]);
			//			subtitleManager.updateSubtitles(linesForSubtitles[0]);
			//			StartCoroutine(waitAndResetSubtitles(interactionLines[0].length));
			//		}
		}
	}
	
	void Update()
	{
		if (puzzle2.inUse && Input.GetKeyDown(KeyCode.Q))
		{
			StartCoroutine(exitPuzzle2());
		}
	}
	
	public IEnumerator exitPuzzle2()
	{
		GameObject.Find ("EscapeText").GetComponent<Text>().enabled = false;
		GameObject.Find ("EscapeText").GetComponent<Outline>().enabled = false;

		Debug.Log ("FIX2");

		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();

		CSM.isFadingIn = false;
		
		yield return new WaitForSeconds(0.3f);
		
		GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
		GameObject.Find("Puzzle2FixDetectiveCamera").GetComponent<Camera>().enabled = false;
		
		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();
		
		puzzle2.inUse = false;
		
		yield return new WaitForSeconds(0.3f);
		
		CSM.isFadingIn = true;
	}
}