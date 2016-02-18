using UnityEngine;
using System.Collections;

public class TerminalInteractionEvent : InteractionEvent 
{
    public Terminal mainTerminal;
    public Transform terminalFixPoint;

    public override IEnumerator interactionEvents()
    {
        TargetManager.disableTargets();

        yield return new WaitForSeconds(0.3f);

        CSM.isFadingIn = false;

        yield return new WaitForSeconds(0.3f);

        GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = false;
        GameObject.Find("TerminalCamera").GetComponent<Camera>().enabled = true;

        mainTerminal.inUse = true;

        yield return new WaitForSeconds(0.3f);

        CSM.isFadingIn = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().ResetPath();
    }
}
