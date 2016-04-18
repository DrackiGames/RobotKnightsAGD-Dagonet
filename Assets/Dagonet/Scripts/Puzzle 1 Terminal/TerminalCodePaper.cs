using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TerminalCodePaper : MonoBehaviour
{
    public Color transparentish;
    public Sprite[] numbers;
    public bool inUse = false;

    [SerializeField]
    private Text escapeText;

    [SerializeField]
    private Terminal terminal;
	[SerializeField]
	private PlaceParts puzzle2;

    public void setupTerminalParchment(string par1TerminalCode)
    {
        SpriteRenderer[] numbersOnParchment = GetComponentsInChildren<SpriteRenderer>();

        List<int> alreadyTaken = new List<int>();

        for (int i = 0; i < par1TerminalCode.Length; i++)
        {
            bool correctPlacement = false;
            int randomNumber = 0;

            while (!correctPlacement)
            {
                randomNumber = Random.Range(0, numbersOnParchment.Length);
                if (!alreadyTaken.Contains(randomNumber))
                {
                    correctPlacement = true;
                    alreadyTaken.Add(randomNumber);
                }
            }

            numbersOnParchment[randomNumber].sprite = numbers[System.Convert.ToInt16(par1TerminalCode[i].ToString()) - 1];
            numbersOnParchment[randomNumber].transform.localScale *= 1.3f;
            numbersOnParchment[randomNumber].transform.Rotate(Vector3.forward, Random.Range(0, 360.0f));

            alreadyTaken.Add(randomNumber);
        }

        for (int t = 0; t < numbersOnParchment.Length; t++)
        {
            if (!alreadyTaken.Contains(t))
            {
                numbersOnParchment[t].sprite = numbers[Random.Range(0, 9)];
                numbersOnParchment[t].color = transparentish;
            }
        }
    }

    void Update()
    {
        if (inUse)
        {
            if (transform.GetComponent<BoxCollider>().enabled)
            {
                transform.GetComponent<BoxCollider>().enabled = false;
            }
            GetComponent<Target>().resetItemTextCursorAndHint();

			if(!terminal.inUse && !puzzle2.inUse)
            {
                escapeText.enabled = true;
                escapeText.GetComponent<Outline>().enabled = true;
            } 
        }
        else
        {
            if (!transform.GetComponent<BoxCollider>().enabled)
            {
                transform.GetComponent<BoxCollider>().enabled = true;
            }

			if(!terminal.inUse && !puzzle2.inUse)
            {
                escapeText.enabled = false;
                escapeText.GetComponent<Outline>().enabled = false;
            }
        }
    }
}