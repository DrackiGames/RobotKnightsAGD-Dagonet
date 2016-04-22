using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestTextManager : MonoBehaviour {

    public Image questImage;
    public Text questText;
    public float fadeSpeed = 1.0f;

    public bool fadeIn;

	// Use this for initialization
	void Start () 
    {
		fadeIn = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(!fadeIn)
        {
			if(questImage.color.a < 0)
			{
				questImage.color = new Color(1f, 1f, 1f, 0f);
			}
			if(questText.color.a < 0)
			{
				questText.color = new Color(0f, 0f, 0f, 0f);
			}
            questImage.color = new Color(1f, 1f, 1f, questImage.color.a - Time.deltaTime * 2);
            questText.color = new Color(0f, 0f, 0f, questText.color.a - Time.deltaTime * 2);
        }
        if (fadeIn)
        {
			if(questImage.color.a > 1)
			{
				questImage.color = new Color(1f, 1f, 1f, 1f);
			}
			if(questText.color.a > 1)
			{
				questText.color = new Color(0f, 0f, 0f, 1f);
			}
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

		yield return new WaitForSeconds(0.0f);
    }
}
