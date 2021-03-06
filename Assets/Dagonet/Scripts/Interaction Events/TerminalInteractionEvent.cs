﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TerminalInteractionEvent : InteractionEvent 
{
    public Terminal mainTerminal;
    [SerializeField]
    private AudioClip[] interactionLines;
    [SerializeField]
    private string[] linesForSubtitles;

    public override IEnumerator interactionEvents()
    {
        yield return new WaitForSeconds(0.3f);

        CSM.isFadingIn = false;

        yield return new WaitForSeconds(0.3f);

        GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = false;
        GameObject.Find("TerminalCamera").GetComponent<Camera>().enabled = true;

        mainTerminal.inUse = true;

        yield return new WaitForSeconds(0.3f);

		GameObject.Find ("EscapeText").GetComponent<Text>().enabled = true;
		GameObject.Find ("EscapeText").GetComponent<Outline>().enabled = true;

        CSM.isFadingIn = true;
		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();

        yield return new WaitForSeconds(0.5f);

        if (!GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().isPlaying)
        {
            GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().PlayOneShot(interactionLines[0]);
            subtitleManager.updateSubtitles(linesForSubtitles[0]);
            StartCoroutine(waitAndResetSubtitles(interactionLines[0].length));
        }
    }

	void Update()
	{
		if (mainTerminal.inUse && Input.GetKeyDown(KeyCode.Q) && !CSM.qCooldown)
		{
			StartCoroutine(CSM.qCoolDownProcess());
			StartCoroutine(exitTerminal());
		}
	}

	private IEnumerator exitTerminal()
	{
		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();
	
		CSM.isFadingIn = false;
		
		yield return new WaitForSeconds(0.3f);
		
		GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
		GameObject.Find("TerminalCamera").GetComponent<Camera>().enabled = false;

		Debug.Log ("Terminal Camera disabled");

		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();
		
		mainTerminal.inUse = false;

		yield return new WaitForSeconds(0.3f);

		GameObject.Find ("EscapeText").GetComponent<Text>().enabled = false;
		GameObject.Find ("EscapeText").GetComponent<Outline>().enabled = false;
		
		CSM.isFadingIn = true;
	}
}
