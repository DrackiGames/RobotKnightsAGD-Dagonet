using UnityEngine;
using System.Collections;

public class OfficeCourtyardDoorInteractionEvent : InteractionEvent
{
	public Transform courtyardEntryPointLocation;
	
	public string sceneCamera1;
	public string sceneCamera2;

	public DialogueManager dialogueManager;
	public QuestTextManager questTextManager;

	public bool hintInvestigateArea;

	void Start()
	{
		hintInvestigateArea = false;
	}
	
	public override IEnumerator interactionEvents()
	{
		if(dialogueManager.detectiveCompleted)
		{
			yield return new WaitForSeconds(0.3f);
			
			CSM.isFadingIn = false;
			
			yield return new WaitForSeconds(0.3f);
			
			GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().Warp(courtyardEntryPointLocation.position);
			
			string currentCamera = CSM.currentCamera;
			
			CSM.switchCamera(currentCamera, sceneCamera1);
			CSM.coupleCamera1 = sceneCamera1;
			CSM.coupleCamera2 = sceneCamera2;
			
			GameObject.Find(CSM.coupleCamera1).GetComponent<Camera>().enabled = true;
			
			yield return new WaitForSeconds(0.3f);
			
			CSM.isFadingIn = true;
			GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();

			yield return new WaitForSeconds(2.0f);

			if(!hintInvestigateArea)
			{
				hintInvestigateArea = true;
				questTextManager.popUpQuest("INVESTIGATE THE AREA BEFORE TALKING TO OTHER CHARACTERS");
			}
		}
	}
}
