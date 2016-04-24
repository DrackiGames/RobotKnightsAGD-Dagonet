using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DetectiveBodyInteractionEvent : InteractionEvent 
{
	[SerializeField]
	private PlaceParts puzzle2;

	public override IEnumerator interactionEvents()
	{
		if(!puzzle2.isDetectiveFound())
		{
			puzzle2.foundDetective();
		}
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
		}
	}
	
	void Update()
	{
		if (puzzle2.inUse && Input.GetKeyDown(KeyCode.Q) && !CSM.qCooldown)
		{
			StartCoroutine(CSM.qCoolDownProcess());
			StartCoroutine(exitPuzzle2());
		}
	}
	
	public IEnumerator exitPuzzle2()
	{
		GameObject.Find ("EscapeText").GetComponent<Text>().enabled = false;
		GameObject.Find ("EscapeText").GetComponent<Outline>().enabled = false;

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