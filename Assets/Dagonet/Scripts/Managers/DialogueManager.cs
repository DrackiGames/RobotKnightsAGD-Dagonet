using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour 
{
	[SerializeField]
	private DetectiveInteractionEvent detectiveEvent;

	[SerializeField]
	private ChoiceButton[] choiceButtons;
	[SerializeField]
	private SubtitleManager subtitleManager;
	[SerializeField]
	private CameraSwitchManager CSM;

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

		if (choiceCurrentID == 0) { //Detective Choice 1
			if (choiceSelected == 1) {
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
			if (choiceSelected == 2) {
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
				
				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraDetective").GetComponent<Camera> ().enabled = false;
			}
			if(choiceSelected == 2)
			{
				detectiveEvent.speak (detectiveChoice3Clips[1], detectiveChoice3Subtitles[1]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[1].length + 0.3f);

				detectiveEvent.speak (detectiveChoice3Clips[4], detectiveChoice3Subtitles[4]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[4].length + 0.3f);
				
				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraDetective").GetComponent<Camera> ().enabled = false;
			}
			if(choiceSelected == 3)
			{
				detectiveEvent.speak (detectiveChoice3Clips[2], detectiveChoice3Subtitles[2]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[2].length + 0.3f);

				detectiveEvent.speak (detectiveChoice3Clips[4], detectiveChoice3Subtitles[4]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[4].length + 0.3f);
				
				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraDetective").GetComponent<Camera> ().enabled = false;
			}
			if(choiceSelected == 4)
			{
				detectiveEvent.speak (detectiveChoice3Clips[3], detectiveChoice3Subtitles[3]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[3].length + 0.3f);

				detectiveEvent.speak (detectiveChoice3Clips[4], detectiveChoice3Subtitles[4]);
				
				yield return new WaitForSeconds(detectiveChoice3Clips[4].length + 0.3f);
				
				GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
				GameObject.Find ("CutsceneCameraDetective").GetComponent<Camera> ().enabled = false;
			}
		}

		yield return new WaitForSeconds(0.0f);
	}
}
