using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ParchmentBoardInteractionEvent : InteractionEvent 
{
    public TerminalCodePaper codePaper;
	public Terminal mainTerminal;

    [SerializeField]
    private AudioClip[] interactionLines;
    [SerializeField]
    private string[] linesForSubtitles;
	[SerializeField]
	private QuestTextManager questTextManager;

    public override IEnumerator interactionEvents()
    {
        yield return new WaitForSeconds(0.3f);

        CSM.isFadingIn = false;

        yield return new WaitForSeconds(0.3f);

        GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = false;
        GameObject.Find("Puzzle1PaperCamera").GetComponent<Camera>().enabled = true;

        codePaper.inUse = true;

        yield return new WaitForSeconds(0.3f);

		GameObject.Find ("EscapeText").GetComponent<Text>().enabled = true;
		GameObject.Find ("EscapeText").GetComponent<Outline>().enabled = true;

        CSM.isFadingIn = true;
		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();

        yield return new WaitForSeconds(0.5f);

		if(!mainTerminal.cracked)
		{
			questTextManager.popUpQuest ("FIGURE OUT THE CODE FROM THE NUMBERS");
		}

        if (!GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().isPlaying)
        {
            GameObject.Find(CSM.currentCamera).GetComponent<AudioSource>().PlayOneShot(interactionLines[0]);
            subtitleManager.updateSubtitles(linesForSubtitles[0]);
            StartCoroutine(waitAndResetSubtitles(interactionLines[0].length));
        }
    }

    void Update()
    {
        if (codePaper.inUse && Input.GetKeyDown(KeyCode.Q) && !CSM.qCooldown)
        {
			StartCoroutine(CSM.qCoolDownProcess());
            StartCoroutine(exitCodePaper());
        }
    }

    private IEnumerator exitCodePaper()
    {
		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();

        CSM.isFadingIn = false;

        yield return new WaitForSeconds(0.3f);

        GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
        GameObject.Find("Puzzle1PaperCamera").GetComponent<Camera>().enabled = false;

		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();

        codePaper.inUse = false;

        yield return new WaitForSeconds(0.3f);

		GameObject.Find ("EscapeText").GetComponent<Text>().enabled = false;
		GameObject.Find ("EscapeText").GetComponent<Outline>().enabled = false;

        CSM.isFadingIn = true;
    }
}
