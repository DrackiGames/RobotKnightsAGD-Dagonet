using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditsSystemManager : MonoBehaviour 
{
	[SerializeField]
	private GateTerminal gateTerminal;
	[SerializeField]
	private EndGame endGameProcessor;
	[SerializeField]
	private Transform creditsImage;
	[SerializeField]
	private Transform creditsText;
	[SerializeField]
	private Transform endOfCreditsText;
	[SerializeField]
	private AudioSource creditsMusicSource;
	[SerializeField]
	private AudioClip creditsMusic;

	private bool startedProcedureEndGame;
	private bool creditsAppear;
	private bool creditsScroll;
	private bool hasCreditsFinished;

	void Start()
	{
		startedProcedureEndGame = false;
		creditsAppear = false;
		creditsScroll = false;
		hasCreditsFinished = false;
	}
	
	void Update () 
	{
		if(!startedProcedureEndGame && gateTerminal.isCompleted() && endGameProcessor.isEndOfGame())
		{
			startedProcedureEndGame = true;
			StartCoroutine(endCreditsProcess());
		}
		if(creditsAppear && creditsImage.GetComponent<Image>().color.a < 1)
		{
			Color currentColour = creditsImage.GetComponent<Image>().color;
			creditsImage.GetComponent<Image>().color = new Color(currentColour.r, currentColour.g, currentColour.b, currentColour.a + Time.deltaTime * 2);
		}
		if(creditsScroll)
		{
			creditsText.Translate(0, 40 * Time.deltaTime, 0);
		}
		if(hasCreditsFinished && Input.GetKey(KeyCode.Return))
		{
			Application.LoadLevel(0);
		}

		if(Input.GetKeyDown(KeyCode.P))
		{
			GameObject.Find ("InventoryManager").GetComponent<InventoryManager>().addToInventory("batteryItem1");
			GameObject.Find ("InventoryManager").GetComponent<InventoryManager>().addToInventory("batteryItem2");
		}
	}

	private IEnumerator endCreditsProcess()
	{
		yield return new WaitForSeconds(1.0f);

		creditsImage.gameObject.SetActive (true);
		creditsAppear = true;
		
		creditsMusicSource.PlayOneShot(creditsMusic);
		creditsMusicSource.loop = true;

		yield return new WaitForSeconds(0.5f);

		creditsText.gameObject.SetActive (true);

		creditsScroll = true;

		yield return new WaitForSeconds(50);

		creditsScroll = false;

		endOfCreditsText.gameObject.SetActive (true);

		hasCreditsFinished = true;
	}
}
