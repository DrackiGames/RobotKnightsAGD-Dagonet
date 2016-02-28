using UnityEngine;
using System.Collections;

public class ParchmentBoardInteractionEvent : InteractionEvent 
{
    public TerminalCodePaper codePaper;

    [SerializeField]
    private AudioClip[] interactionLines;
    [SerializeField]
    private string[] linesForSubtitles;

    public override IEnumerator interactionEvents()
    {
        TargetManager.disableTargets();

        yield return new WaitForSeconds(0.3f);

        CSM.isFadingIn = false;

        yield return new WaitForSeconds(0.3f);

        GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = false;
        GameObject.Find("Puzzle1PaperCamera").GetComponent<Camera>().enabled = true;

        codePaper.inUse = true;

        yield return new WaitForSeconds(0.3f);

        CSM.isFadingIn = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().ResetPath();

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
        if (codePaper.inUse && Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(exitCodePaper());
        }
    }

    private IEnumerator exitCodePaper()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().ResetPath();

        CameraSwitchManager CSM = GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>();
        CSM.isFadingIn = false;

        yield return new WaitForSeconds(0.3f);

        GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
        GameObject.Find("Puzzle1PaperCamera").GetComponent<Camera>().enabled = false;

        GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().ResetPath();

        codePaper.inUse = false;

        yield return new WaitForSeconds(0.3f);

        CSM.isFadingIn = true;
        TargetManager.enableTargets();
    }
}
