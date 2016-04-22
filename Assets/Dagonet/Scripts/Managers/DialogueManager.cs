using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour 
{
	[SerializeField]
	private DetectiveInteractionEvent detectiveEvent;
	[SerializeField]
	private GangsterInteractionEvent gangsterEvent;
	[SerializeField]
	private LeaderInteractionEvent leaderEvent;
	public bool detectiveCompleted;
	public bool gangsterCompleted;
	public bool leaderCompleted;

	[SerializeField]
	private ChoiceButton[] choiceButtons;
	[SerializeField]
	private SubtitleManager subtitleManager;
	[SerializeField]
	private CameraSwitchManager CSM;
	[SerializeField]
	private InventoryManager inventoryManager;
	[SerializeField]
	private QuestTextManager questTextManager;

	[SerializeField]
	private int choiceCurrentID;
	[SerializeField]
	private int choiceSelected; //-1 is nothing, 1 -> n are choices

	[SerializeField]
	private AudioClip[] detectiveChoice1Clips;
	[SerializeField]
	private string[] detectiveChoice1Subtitles;
	[SerializeField]
	private AudioClip[] detectiveChoice2Clips;
	[SerializeField]
	private string[] detectiveChoice2Subtitles;
	[SerializeField]
	private AudioClip[] detectiveChoice3Clips;
	[SerializeField]
	private string[] detectiveChoice3Subtitles;

	[SerializeField]
	private AudioClip[] gangsterChoice1Clips;
	[SerializeField]
	private string[] gangsterChoice1Subtitles;

	[SerializeField]
	private AudioClip[] gangsterChoice2Clips;
	[SerializeField]
	private string[] gangsterChoice2Subtitles;

	[SerializeField]
	private AudioClip[] leaderChoice1Clips;
	[SerializeField]
	private string[] leaderChoice1Subtitles;

	[SerializeField]
	private AudioClip[] leaderChoice2Clips;
	[SerializeField]
	private string[] leaderChoice2Subtitles;
	
	void Start () 
	{

	}

	void Update () 
	{
	
	}

	public bool choicesEnabled()
	{
		return choiceButtons [0].gameObject.activeSelf;
	}

	public void choiceTwoSetup(string par1Choice1, string par2Choice2)
	{
		for(int i = 0; i < 2; i++)
		{
			choiceButtons[i].gameObject.SetActive(true);
		}
		choiceButtons [0].GetComponentInChildren<Text> ().text = par1Choice1;
		choiceButtons [1].GetComponentInChildren<Text> ().text = par2Choice2;
	}

	public void choiceFourSetup(string par1Choice1, string par2Choice2, string par3Choice3, string par4Choice4)
	{
		for(int i = 0; i < 4; i++)
		{
			choiceButtons[i].gameObject.SetActive(true);
		}
		choiceButtons [0].GetComponentInChildren<Text> ().text = par1Choice1;
		choiceButtons [1].GetComponentInChildren<Text> ().text = par2Choice2;
		choiceButtons [2].GetComponentInChildren<Text> ().text = par3Choice3;
		choiceButtons [3].GetComponentInChildren<Text> ().text = par4Choice4;
	}

	public void disableChoiceButtons()
	{
		foreach(ChoiceButton choiceButton in choiceButtons)
		{
			choiceButton.shrinkButton();
			choiceButton.gameObject.SetActive(false);
		}
	}

	public void setCurrentChoiceID(int par1ChoiceID)
	{
		choiceCurrentID = par1ChoiceID;
		choiceButtons [2].transform.localScale = new Vector3 (1, 1, 1);
		choiceButtons [3].transform.localScale = new Vector3 (1, 1, 1);
	}

	public void setChoiceSelected (int par1ChoiceID)
	{
		choiceSelected = par1ChoiceID;
	}

	public void choiceProcess()
	{
		StartCoroutine (choices ());
	}

	public IEnumerator choices()
	{
		disableChoiceButtons ();

		yield return new WaitForSeconds (0.25f);

		if (choiceCurrentID == 0)  //Detective Choice 1
		{
			if (choiceSelected == 1) 
			{
				detectiveEvent.speak (detectiveChoice1Clips [0], detectiveChoice1Subtitles [0]);
				
				yield return new WaitForSeconds (detectiveChoice1Clips [0].length + 0.3f);

				detectiveEvent.speak (detectiveChoice1Clips [1], detectiveChoice1Subtitles [1]);
				
				yield return new WaitForSeconds (detectiveChoice1Clips [1].length + 0.3f);
				
				detectiveEvent.speak (detectiveChoice1Clips [2], detectiveChoice1Subtitles [2]);
				
				yield return new WaitForSeconds (detectiveChoice1Clips [2].length + 0.3f);
				
				detectiveEvent.speak (detectiveChoice1Clips [3], detectiveChoice1Subtitles [3]);
				
				yield return new WaitForSeconds (detectiveChoice1Clips [3].length + 0.3f);
				
				choiceSelected = -1;
				
				//Choice starts here
				choiceFourSetup ("A dream", "Another world", "A really shit office", "The future");
				
				setCurrentChoiceID (1);
			}
			if (choiceSelected == 2) 
			{
				detectiveEvent.speak (detectiveChoice2Clips [0], detectiveChoice2Subtitles [0]);
				
				yield return new WaitForSeconds (detectiveChoice2Clips [0].length + 0.3f);

				detectiveEvent.speak (detectiveChoice1Clips [1], detectiveChoice1Subtitles [1]);
				
				yield return new WaitForSeconds (detectiveChoice1Clips [1].length + 0.3f);
				
				detectiveEvent.speak (detectiveChoice1Clips [2], detectiveChoice1Subtitles [2]);
				
				yield return new WaitForSeconds (detectiveChoice1Clips [2].length + 0.3f);
				
				detectiveEvent.speak (detectiveChoice1Clips [3], detectiveChoice1Subtitles [3]);
				
				yield return new WaitForSeconds (detectiveChoice1Clips [3].length + 0.3f);
				
				choiceSelected = -1;
				
				//Choice starts here
				choiceFourSetup ("A dream", "Another world", "A really shit office", "The future");
				
				setCurrentChoiceID (1);
			}
		}
		if(choiceCurrentID == 1) //Detective Choice 2
		{
			if(choiceSelected == 1)
			{
				detectiveEvent.speak (detectiveChoice3Clips[0], detectiveChoice3Subtitles[0]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[0].length + 0.3f);

				detectiveEvent.speak (detectiveChoice3Clips[4], detectiveChoice3Subtitles[4]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[4].length + 0.3f);

				detectiveEvent.speak (detectiveChoice3Clips[5], detectiveChoice3Subtitles[5]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[5].length + 0.3f);
				
				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraDetective").GetComponent<Camera> ().enabled = false;

				detectiveCompleted = true;
			}
			if(choiceSelected == 2)
			{
				detectiveEvent.speak (detectiveChoice3Clips[1], detectiveChoice3Subtitles[1]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[1].length + 0.3f);

				detectiveEvent.speak (detectiveChoice3Clips[4], detectiveChoice3Subtitles[4]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[4].length + 0.3f);

				detectiveEvent.speak (detectiveChoice3Clips[5], detectiveChoice3Subtitles[5]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[5].length + 0.3f);
				
				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraDetective").GetComponent<Camera> ().enabled = false;

				detectiveCompleted = true;
			}
			if(choiceSelected == 3)
			{
				detectiveEvent.speak (detectiveChoice3Clips[2], detectiveChoice3Subtitles[2]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[2].length + 0.3f);

				detectiveEvent.speak (detectiveChoice3Clips[4], detectiveChoice3Subtitles[4]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[4].length + 0.3f);

				detectiveEvent.speak (detectiveChoice3Clips[5], detectiveChoice3Subtitles[5]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[5].length + 0.3f);
				
				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraDetective").GetComponent<Camera> ().enabled = false;

				detectiveCompleted = true;
			}
			if(choiceSelected == 4)
			{
				detectiveEvent.speak (detectiveChoice3Clips[3], detectiveChoice3Subtitles[3]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[3].length + 0.3f);

				detectiveEvent.speak (detectiveChoice3Clips[4], detectiveChoice3Subtitles[4]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[4].length + 0.3f);

				detectiveEvent.speak (detectiveChoice3Clips[5], detectiveChoice3Subtitles[5]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[5].length + 0.3f);
				
				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraDetective").GetComponent<Camera> ().enabled = false;

				detectiveCompleted = true;
			}
		}
		if(choiceCurrentID == 2)
		{
			if(choiceSelected == 1)
			{
				gangsterEvent.speak (gangsterChoice1Clips[0], gangsterChoice1Subtitles[0]);
				
				yield return new WaitForSeconds(gangsterChoice1Clips[0].length + 0.3f);

				gangsterEvent.speak (gangsterChoice1Clips[1], gangsterChoice1Subtitles[1]);
				
				yield return new WaitForSeconds(gangsterChoice1Clips[1].length + 0.3f);

				gangsterEvent.speak (gangsterChoice1Clips[2], gangsterChoice1Subtitles[2]);
				
				yield return new WaitForSeconds(gangsterChoice1Clips[2].length + 0.3f);

				gangsterEvent.speak (gangsterChoice1Clips[3], gangsterChoice1Subtitles[3]);
				
				yield return new WaitForSeconds(gangsterChoice1Clips[3].length + 0.3f);

				gangsterEvent.speak (gangsterChoice1Clips[7], gangsterChoice1Subtitles[7]);
				
				yield return new WaitForSeconds(gangsterChoice1Clips[7].length + 0.3f);

				choiceSelected = -1;
				
				//Choice starts here
				choiceFourSetup ("I need the battery for treasure \nbehind the gate", "Give the battery for unique \nrobot parts behind the gate", "[AGRESSIVELY ARGUE]", "I will help you slay the leader");
				
				setCurrentChoiceID (3);
			}
			if(choiceSelected == 2)
			{
				gangsterEvent.speak (gangsterChoice1Clips[4], gangsterChoice1Subtitles[4]);
				
				yield return new WaitForSeconds(gangsterChoice1Clips[4].length + 0.3f);
				
				gangsterEvent.speak (gangsterChoice1Clips[5], gangsterChoice1Subtitles[5]);
				
				yield return new WaitForSeconds(gangsterChoice1Clips[5].length + 0.3f);
				
				gangsterEvent.speak (gangsterChoice1Clips[6], gangsterChoice1Subtitles[6]);
				
				yield return new WaitForSeconds(gangsterChoice1Clips[6].length + 0.3f);

				gangsterEvent.speak (gangsterChoice1Clips[7], gangsterChoice1Subtitles[7]);
				
				yield return new WaitForSeconds(gangsterChoice1Clips[7].length + 0.3f);

				choiceSelected = -1;
				
				//Choice starts here
				choiceFourSetup ("I need the battery for treasure \nbehind the gate", "Give the battery for unique \nrobot parts behind the gate", "[AGGRESSIVELY ARGUE]", "I will help you slay the leader");
				
				setCurrentChoiceID (3);
			}
		}
		if(choiceCurrentID == 3)
		{
			if(choiceSelected == 1)
			{
				gangsterEvent.speak (gangsterChoice2Clips[0], gangsterChoice2Subtitles[0]);
				
				yield return new WaitForSeconds(gangsterChoice2Clips[0].length + 0.3f);

				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraGangster").GetComponent<Camera> ().enabled = false;

				gangsterCompleted = true;
			}
			if(choiceSelected == 2)
			{
				gangsterEvent.speak (gangsterChoice2Clips[1], gangsterChoice2Subtitles[1]);
				
				yield return new WaitForSeconds(gangsterChoice2Clips[1].length + 0.3f);

				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraGangster").GetComponent<Camera> ().enabled = false;

				inventoryManager.addToInventory("batteryItem1");

				gangsterCompleted = true;
			}
			if(choiceSelected == 3)
			{
				gangsterEvent.speak (gangsterChoice2Clips[2], gangsterChoice2Subtitles[2]);
				
				yield return new WaitForSeconds(gangsterChoice2Clips[2].length + 0.3f);

				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraGangster").GetComponent<Camera> ().enabled = false;

				gangsterCompleted = true;
			}
			if(choiceSelected == 4)
			{
				gangsterEvent.speak (gangsterChoice2Clips[3], gangsterChoice2Subtitles[3]);
				
				yield return new WaitForSeconds(gangsterChoice2Clips[3].length + 0.3f);

				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraGangster").GetComponent<Camera> ().enabled = false;

				inventoryManager.addToInventory("batteryItem1");

				gangsterCompleted = true;
			}
		}
		if(choiceCurrentID == 4)
		{
			if(choiceSelected == 1)
			{
				leaderEvent.speak (leaderChoice1Clips [0], leaderChoice1Subtitles [0]);
				
				yield return new WaitForSeconds (leaderChoice1Clips [0].length + 0.3f);
				
				leaderEvent.speak (leaderChoice1Clips [1], leaderChoice1Subtitles [1]);
				
				yield return new WaitForSeconds (leaderChoice1Clips [1].length + 0.3f);
				
				leaderEvent.speak (leaderChoice1Clips [2], leaderChoice1Subtitles [2]);
				
				yield return new WaitForSeconds (leaderChoice1Clips [2].length + 0.3f);
				
				leaderEvent.speak (leaderChoice1Clips [3], leaderChoice1Subtitles [3]);
				
				yield return new WaitForSeconds (leaderChoice1Clips [3].length + 0.3f);

				leaderEvent.speak (leaderChoice1Clips [7], leaderChoice1Subtitles [7]);
				
				yield return new WaitForSeconds (leaderChoice1Clips [7].length + 0.3f);
				
				leaderEvent.speak (leaderChoice1Clips [8], leaderChoice1Subtitles [8]);
				
				yield return new WaitForSeconds (leaderChoice1Clips [8].length + 0.3f);
				
				leaderEvent.speak (leaderChoice1Clips [9], leaderChoice1Subtitles [9]);
				
				yield return new WaitForSeconds (leaderChoice1Clips [9].length + 0.3f);
				
				leaderEvent.speak (leaderChoice1Clips [10], leaderChoice1Subtitles [10]);
				
				yield return new WaitForSeconds (leaderChoice1Clips [10].length + 0.3f);
				
				choiceSelected = -1;
				
				//Choice starts here
				choiceFourSetup ("A time clash of \nnew and old", "A weird new \norganisation", "A Gangster symbol", "Some boring rubbish");
				
				setCurrentChoiceID (5);
			}
			if(choiceSelected == 2)
			{
				leaderEvent.speak (leaderChoice1Clips [4], leaderChoice1Subtitles [4]);
				
				yield return new WaitForSeconds (leaderChoice1Clips [4].length + 0.3f);
				
				leaderEvent.speak (leaderChoice1Clips [5], leaderChoice1Subtitles [5]);
				
				yield return new WaitForSeconds (leaderChoice1Clips [5].length + 0.3f);
				
				leaderEvent.speak (leaderChoice1Clips [6], leaderChoice1Subtitles [6]);
				
				yield return new WaitForSeconds (leaderChoice1Clips [6].length + 0.3f);

				leaderEvent.speak (leaderChoice1Clips [7], leaderChoice1Subtitles [7]);
				
				yield return new WaitForSeconds (leaderChoice1Clips [7].length + 0.3f);
				
				leaderEvent.speak (leaderChoice1Clips [8], leaderChoice1Subtitles [8]);
				
				yield return new WaitForSeconds (leaderChoice1Clips [8].length + 0.3f);
				
				leaderEvent.speak (leaderChoice1Clips [9], leaderChoice1Subtitles [9]);
				
				yield return new WaitForSeconds (leaderChoice1Clips [9].length + 0.3f);
				
				leaderEvent.speak (leaderChoice1Clips [10], leaderChoice1Subtitles [10]);
				
				yield return new WaitForSeconds (leaderChoice1Clips [10].length + 0.3f);

				choiceSelected = -1;
				
				//Choice starts here
				choiceFourSetup ("A time clash of \nnew and old", "A weird new \norganisation", "A Gangster symbol", "Some boring rubbish");
				
				setCurrentChoiceID (5);
			}
		}
		if(choiceCurrentID == 5)
		{
			if(choiceSelected == 1)
			{
				leaderEvent.speak (leaderChoice2Clips [0], leaderChoice2Subtitles [0]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [0].length + 0.3f);

				leaderEvent.speak (leaderChoice2Clips [4], leaderChoice2Subtitles [4]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [4].length + 0.3f);

				leaderEvent.speak (leaderChoice2Clips [5], leaderChoice2Subtitles [5]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [5].length + 0.3f);

				leaderEvent.speak (leaderChoice2Clips [6], leaderChoice2Subtitles [6]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [6].length + 0.3f);

				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraLeader").GetComponent<Camera> ().enabled = false;
				
				inventoryManager.addToInventory("batteryItem2");
				
				leaderCompleted = true;
			}
			if(choiceSelected == 2)
			{
				leaderEvent.speak (leaderChoice2Clips [1], leaderChoice2Subtitles [1]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [1].length + 0.3f);

				leaderEvent.speak (leaderChoice2Clips [4], leaderChoice2Subtitles [4]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [4].length + 0.3f);
				
				leaderEvent.speak (leaderChoice2Clips [5], leaderChoice2Subtitles [5]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [5].length + 0.3f);
				
				leaderEvent.speak (leaderChoice2Clips [6], leaderChoice2Subtitles [6]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [6].length + 0.3f);

				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraLeader").GetComponent<Camera> ().enabled = false;
				
				inventoryManager.addToInventory("batteryItem2");
				
				leaderCompleted = true;
			}
			if(choiceSelected == 3)
			{
				leaderEvent.speak (leaderChoice2Clips [2], leaderChoice2Subtitles [2]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [2].length + 0.3f);

				leaderEvent.speak (leaderChoice2Clips [4], leaderChoice2Subtitles [4]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [4].length + 0.3f);
				
				leaderEvent.speak (leaderChoice2Clips [5], leaderChoice2Subtitles [5]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [5].length + 0.3f);
				
				leaderEvent.speak (leaderChoice2Clips [6], leaderChoice2Subtitles [6]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [6].length + 0.3f);

				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraLeader").GetComponent<Camera> ().enabled = false;
				
				inventoryManager.addToInventory("batteryItem2");
				
				leaderCompleted = true;
			}
			if(choiceSelected == 4)
			{
				leaderEvent.speak (leaderChoice2Clips [3], leaderChoice2Subtitles [3]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [3].length + 0.3f);

				leaderEvent.speak (leaderChoice2Clips [4], leaderChoice2Subtitles [4]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [4].length + 0.3f);
				
				leaderEvent.speak (leaderChoice2Clips [5], leaderChoice2Subtitles [5]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [5].length + 0.3f);
				
				leaderEvent.speak (leaderChoice2Clips [6], leaderChoice2Subtitles [6]);
				
				yield return new WaitForSeconds (leaderChoice2Clips [6].length + 0.3f);

				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraLeader").GetComponent<Camera> ().enabled = false;
				
				inventoryManager.addToInventory("batteryItem2");
				
				leaderCompleted = true;
			}
		}

		yield return new WaitForSeconds(0.0f);
	}
}
