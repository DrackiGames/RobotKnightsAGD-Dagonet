using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial : MonoBehaviour 
{
    [SerializeField]
    private Transform tutorialPanel;
    [SerializeField]
	private Text hintTitle;
    [SerializeField]
	private Text hintText;
    [SerializeField]
	private Button previousButton;
    [SerializeField]
	private Button nextButton;
	[SerializeField]
	private Button doneButton;
    [SerializeField]
	private Transform textPrompt;
    [SerializeField]
	private Image hintImageObject;
    [SerializeField]
	private Sprite hintSprite1;
    [SerializeField]
	private Sprite hintSprite2;
    [SerializeField]
	private Sprite hintSprite3;
    [SerializeField]
	private Sprite hintSprite4;
    [SerializeField]
	private Sprite hintSprite5;
    [SerializeField]
	private Sprite hintSprite6;
    [SerializeField]
	private Sprite hintSprite7;
	[SerializeField]
	private QuestTextManager questTextManager;
	[SerializeField]
	private CursorManager cursorManager;

    private int hintNumber;
    //private string hintText;
    private bool isActive;
    private bool hintChanged;
	private bool firstTimeInactive;
	
	void Start () 
    {
        hintNumber = 1;
        isActive = true;
        hintChanged = true;
		firstTimeInactive = false;
	}

	void Update () 
    {
        if (hintNumber == 1 && previousButton.gameObject.activeInHierarchy == true)
		{
			previousButton.gameObject.SetActive(false);
		}
        else if (hintNumber > 1 && previousButton.gameObject.activeInHierarchy == false)
		{
			previousButton.gameObject.SetActive(true);
		}

        if (hintNumber == 7 && nextButton.gameObject.activeInHierarchy == true)
		{
			nextButton.gameObject.SetActive(false);
			doneButton.gameObject.SetActive(true);
		}
        else if (hintNumber < 7 && nextButton.gameObject.activeInHierarchy == false)
		{
			nextButton.gameObject.SetActive(true);
			doneButton.gameObject.SetActive(false);
		}

        if (GameObject.Find("Button Manager").GetComponent<PauseButtonScript>().isPaused())
        {
            isActive = false;
            tutorialPanel.gameObject.SetActive(false);
			cursorManager.normal();
        }

	    if (Input.GetKeyDown(KeyCode.T) && !GameObject.Find("Button Manager").GetComponent<PauseButtonScript>().isPaused())
        {
            if (!isActive)
            {
                isActive = true;
                tutorialPanel.gameObject.SetActive(true);
				Debug.Log ("HI");
            }                
            else
            {
                isActive = false;
                tutorialPanel.gameObject.SetActive(false);
            }
        }

        if (hintChanged)
        {
            switch (hintNumber)
            {
                case 1:
                    hintTitle.text = "Inspection";
                    hintText.text = "You can inspect and comment on highlighted objects using your mouse's left click";
                    hintImageObject.sprite = hintSprite1;
                    break;
                case 2:
                    hintTitle.text = "Interaction";
					hintText.text = "You can interact with highlighted objects using your mouse's right click. This can move you to the object and perhaps another puzzle view";
                    hintImageObject.sprite = hintSprite2;
                    break;
                case 3:
                    hintTitle.text = "Movement";
                    hintText.text = "You can move your character by using your mouse's right click on the ground";
                    hintImageObject.sprite = hintSprite3;
                    break;
                case 4:
                    hintTitle.text = "Character Interaction";
                    hintText.text = "You can talk with other characters by using your mouse's right click on them";
                    hintImageObject.sprite = hintSprite4;
                    break;
                case 5:
                    hintTitle.text = "Visor";
                    hintText.text = "You can use your character's visor to view hidden objects which were present in another timeline by using the V key.";
                    hintImageObject.sprite = hintSprite5;
                    break;
                case 6:
                    hintTitle.text = "Switch Cameras";
                    hintText.text = "You can switch between 2 cameras in each room by using the Tab key.";
                    hintImageObject.sprite = hintSprite6;
                    break;
                case 7:
                    hintTitle.text = "Inventory";
                    hintText.text = "You can view items in you inventory by using the I key.";
                    hintImageObject.sprite = hintSprite7;
                    break;
            }

            hintChanged = false;
        }        
	}

    public bool isTutorialUp()
    {
        return isActive;
    }

    public void changeHint(string buttonName)
    {   
        if (buttonName == "Previous Hint" && hintNumber > 1)
        {        
            hintNumber--;
            hintChanged = true;
        }
        else if (buttonName == "Next Hint" && hintNumber < 7)
        {
            hintNumber++;
            hintChanged = true;
        }
    }

	public void skipTutorial()
	{
		hintNumber = 1;
		isActive = false;
		hintChanged = true;
		tutorialPanel.gameObject.SetActive (false);
		cursorManager.normal ();

		if(!firstTimeInactive)
		{
			firstTimeInactive = true;
			questTextManager.popUpQuest("ESCAPE THE TERMINAL ROOM - BY CRACKING THE CODE");
			StartCoroutine(quest ());
		}
	}

	private IEnumerator quest()
	{
		yield return new WaitForSeconds(10);
		
		questTextManager.popUpQuest ("IF STUCK WITH CONTROLS JUST PRESS THE T KEY");
	}
}
