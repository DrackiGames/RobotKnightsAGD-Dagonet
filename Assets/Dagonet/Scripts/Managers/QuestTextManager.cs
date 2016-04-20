using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestTextManager : MonoBehaviour {

    public Image questImage;
    public Text questText;
    public float fadeSpeed = 1.0f;

    private bool fadeIn;

	// Use this for initialization
	void Start () 
    {
		fadeIn = false;

		popUpQuest("ESCAPE THE TERMINAL ROOM!");
	}
	
	// Update is called once per frame
	void	 Update () 
    {
	    if(!fadeIn)
        {
            questImage.color = new Color(1f, 1f, 1f, questImage.color.a - Time.deltaTime * 2);
            questText.color = new Color(0f, 0f, 0f, questText.color.a - Time.deltaTime * 2);
        }
        if (fadeIn)
        {
            questImage.color = new Color(1f, 1f, 1f, questImage.color.a + Time.deltaTime * 2);
            questText.color = new Color(0f, 0f, 0f, questText.color.a + Time.deltaTime * 2);
        }
	}

    public void popUpQuest(string par1Quest)
    {
        questText.text = par1Quest;

        StartCoroutine(questFadeInAndOut());
    }

    IEnumerator questFadeInAndOut()
    {
        fadeIn = true;

        yield return new WaitForSeconds(3);

        fadeIn = false;
    }
}
