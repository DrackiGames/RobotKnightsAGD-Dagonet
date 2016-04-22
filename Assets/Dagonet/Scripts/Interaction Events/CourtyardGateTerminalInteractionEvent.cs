using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CourtyardGateTerminalInteractionEvent : InteractionEvent 
{
	[SerializeField]
	private AudioClip[] interactionLines;
	[SerializeField]
	private string[] linesForSubtitles;
	[SerializeField]
	private InventoryManager inventoryManager;
	
	public override IEnumerator interactionEvents()
	{

		yield return new WaitForSeconds(0.3f);
		
		CSM.isFadingIn = false;
		
		yield return new WaitForSeconds(0.3f);
		
		GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = false;
		GameObject.Find("Puzzle3Camera").GetComponent<Camera>().enabled = true;
		
		yield return new WaitForSeconds(0.3f);
		
		CSM.isFadingIn = true;
		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();
		
		yield return new WaitForSeconds(0.5f);

		GameObject.Find ("EscapeText").GetComponent<Text>().enabled = true;
		GameObject.Find ("EscapeText").GetComponent<Outline>().enabled = true;
		
		if (!GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().isPlaying)
		{
			if(inventoryManager.hasGotItem("batteryItem1") && inventoryManager.hasGotItem("batteryItem2"))
			{
				GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().PlayOneShot(interactionLines[0]);
				subtitleManager.updateSubtitles(linesForSubtitles[0]);
				StartCoroutine(waitAndResetSubtitles(interactionLines[0].length));
			}
			else
			{
				GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().PlayOneShot(interactionLines[1]);
				subtitleManager.updateSubtitles(linesForSubtitles[1]);
				StartCoroutine(waitAndResetSubtitles(interactionLines[1].length));
			}
		}
	}

	void Update()
	{
		if (GameObject.Find("Puzzle3Camera") && Input.GetKeyDown(KeyCode.Q))
		{
			StartCoroutine(exitPuzzle3());
		}
	}
	
	private IEnumerator exitPuzzle3()
	{
		GameObject.Find ("EscapeText").GetComponent<Text>().enabled = false;
		GameObject.Find ("EscapeText").GetComponent<Outline>().enabled = false;

		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();
		
		CameraSwitchManager CSM = GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>();
		CSM.isFadingIn = false;
		
		yield return new WaitForSeconds(0.3f);
		
		GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
		GameObject.Find("Puzzle3Camera").GetComponent<Camera>().enabled = false;
		
		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();
		
		yield return new WaitForSeconds(0.3f);
		
		CSM.isFadingIn = true;
	}
}
