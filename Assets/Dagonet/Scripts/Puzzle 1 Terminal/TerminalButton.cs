using UnityEngine;
using System.Collections;

public class TerminalButton : MonoBehaviour 
{
    public Terminal mainTerminal;
    public string number;

    private Vector3 startingScale;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.gray;
        startingScale = transform.localScale;
    }

    void OnMouseEnter()
    {
        if(mainTerminal.inUse)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            transform.localScale = startingScale * 1.1f;
        }
    }

    void OnMouseExit()
    {
        if (mainTerminal.inUse)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
            transform.localScale = startingScale;
        }
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1) && !mainTerminal.cracked && mainTerminal.inUse)
        {
            if(number == "C") //Cancel Button
            {
                mainTerminal.inputCode = "";
            }
            else
            {
                mainTerminal.inputCode += number;
            }
        }
    }
}
