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
	[SerializeField]
	private GateTerminal gateTerminal;
	
	public override IEnumerator interactionEvents()
	{
		if(!gateTerminal.foundGateTerminal)
		{
			gateTerminal.foundGateTerminal = true;
		}

		yield return new WaitForSeconds(0.3f);
		
		CSM.isFadingIn = false;
		
		yield return new WaitForSeconds(0.3f);
		
		GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = false;
		GameObject.Find("Puzzle3Camera").GetComponent<Camera>().enabled = true;

		gateTerminal.inUse = true;
		
		yield return new WaitForSeconds(0.3f);

		GameObject.Find ("EscapeText").GetComponent<Text>().enabled = true;
		GameObject.Find ("EscapeText").GetComponent<Outline>().enabled = true;
		
		CSM.isFadingIn = true;
		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();
		
		yield return new WaitForSeconds(0.5f);
		
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
		if (GameObject.Find("Puzzle3Camera").GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Q) && !CSM.qCooldown)
		{
			StartCoroutine(CSM.qCoolDownProcess());
			StartCoroutine(exitPuzzle3());
		}
	}
	
	private IEnumerator exitPuzzle3()
	{
		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();

		CSM.isFadingIn = false;
		
		yield return new WaitForSeconds(0.3f);
		
		GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
		GameObject.Find("Puzzle3Camera").GetComponent<Camera>().enabled = false;
		
		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();

		gateTerminal.inUse = false;
		
		yield return new WaitForSeconds(0.3f);

		GameObject.Find ("EscapeText").GetComponent<Text>().enabled = false;
		GameObject.Find ("EscapeText").GetComponent<Outline>().enabled = false;
		
		CSM.isFadingIn = true;
	}
}
