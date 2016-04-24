using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestTextManager : MonoBehaviour {

    public Image questImage;
    public Text questText;

    public bool fadeIn;

	private float timer;
	
	void Start () 
    {
		fadeIn = false;
		timer = 0.0f;
	}

	void Update () 
    {
	    if(!fadeIn)
        {
			questImage.gameObject.SetActive(false);
			questText.gameObject.SetActive(false);
        }
        else
        {
			questImage.gameObject.SetActive(true);
			questText.gameObject.SetActive(true);
        }

		if(fadeIn)
		{
			timer += 4 * Time.deltaTime;
			if(timer > 20)
			{
				timer = 0;
				fadeIn = false;
			}
		}
	}

    public void popUpQuest(string par1Quest)
    {
        questText.text = par1Quest;
		fadeIn = true;
    }
}
