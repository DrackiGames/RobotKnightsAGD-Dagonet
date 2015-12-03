using UnityEngine;
using System.Collections;

public class TerminalTargetFixer : MonoBehaviour 
{
    public Terminal mainTerminal;

    public Transform eye, hand;
	
	// Update is called once per frame
	public void fix () 
    {
        if (mainTerminal.inUse && eye.gameObject.activeInHierarchy && hand.gameObject.activeInHierarchy)
        {
            eye.gameObject.SetActive(false);
            hand.gameObject.SetActive(false);
        }
	}
}
