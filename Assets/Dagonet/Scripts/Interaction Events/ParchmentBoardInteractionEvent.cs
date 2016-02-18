using UnityEngine;
using System.Collections;

public class ParchmentBoardInteractionEvent : InteractionEvent 
{
    public TerminalCodePaper codePaper;
    public override IEnumerator interactionEvents()
    {
        yield return new WaitForSeconds(0.3f);

        CSM.isFadingIn = false;

        yield return new WaitForSeconds(0.3f);

        GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = false;
        GameObject.Find("Puzzle1PaperCamera").GetComponent<Camera>().enabled = true;

        codePaper.inUse = true;

        yield return new WaitForSeconds(0.3f);

        CSM.isFadingIn = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().ResetPath();
    }

    void Update()
    {
        if (codePaper.inUse && Input.GetKeyDown(KeyCode.Escape))
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
