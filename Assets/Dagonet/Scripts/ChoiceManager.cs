using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChoiceManager : MonoBehaviour 
{
    public int[] choiceStatus;
    public bool isOn;

    public Image button1, button2, timer;
    public Text buttonText1, buttonText2;

    private int currentID;
    private bool buttonOne, buttonTwo;

	void Start () 
    {
        isOn = false;
	   for(int choice = 0; choice < choiceStatus.Length; choice++)
       {
           choiceStatus[choice] = 0;
           //Read from data file eventually
       }
	}
	
	void Update ()
    {
	    if(!isOn)
        {
            button1.color = new Color(Color.white.r, Color.white.g, Color.white.b, 0.4f);
            button1.enabled = false;
            button2.color = new Color(Color.white.r, Color.white.g, Color.white.b, 0.4f);
            button2.enabled = false;
            buttonText1.enabled = false;
            buttonText2.enabled = false;
            timer.enabled = false;
            timer.rectTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            buttonOne = false;
            buttonTwo = false;
        }
        else
        {
            button1.enabled = true;
            button2.enabled = true;
            buttonText1.enabled = true;
            buttonText2.enabled = true;
            timer.enabled = true;

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                button1.color = new Color(Color.green.r, Color.green.g, Color.green.b, 0.4f);
                button2.color = new Color(Color.white.r, Color.white.g, Color.white.b, 0.4f);

                buttonOne = true;
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                button2.color = new Color(Color.green.r, Color.green.g, Color.green.b, 0.4f);
                button1.color = new Color(Color.white.r, Color.white.g, Color.white.b, 0.4f);

                buttonTwo = true;
            }

            if (timer.rectTransform.localScale.x >= 0)
            {
                timer.rectTransform.localScale = new Vector3(timer.rectTransform.localScale.x - (Time.deltaTime / 4), 1.0f, 1.0f);
            }
            else
            {
                isOn = false;
                if (buttonOne)
                {
                    choiceStatus[currentID] = 1;
                }
                else if (buttonTwo)
                {
                    choiceStatus[currentID] = 2;
                }
                else
                {
                    choiceStatus[currentID] = Random.Range(1, 3);
                }
            }
        }

        if(!isOn)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                displayChoice(0, "Let the robot live", "Disconnect the robot");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                displayChoice(1, "Help the Detective", "Mislead the Detective");
            }
        }
        
	}

    public void displayChoice(int par1ChoiceID, string par2Choice1Text, string par3Choice2Text)
    {
        isOn = true;
        buttonText1.text = par2Choice1Text;
        buttonText2.text = par3Choice2Text;
        currentID = par1ChoiceID;
    }
}
