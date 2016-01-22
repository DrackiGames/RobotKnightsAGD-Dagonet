using UnityEngine;
using System.Collections;

public class TerminalInteractionEvent : InteractionEvent 
{
    public Terminal mainTerminal;
    public Transform terminalFixPoint;

    public override IEnumerator interactionEvents()
    {
        yield return new WaitForSeconds(0.3f);

        CameraSwitchManager CSM = GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>();
        CSM.isFadingIn = false;

        yield return new WaitForSeconds(0.3f);

        GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = false;
        GameObject.Find("TerminalCamera").GetComponent<Camera>().enabled = true;

        mainTerminal.inUse = true;

        yield return new WaitForSeconds(0.3f);

        GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().Move(new Vector3(0, 0, -0.5f));

        CSM.isFadingIn = true;
    }
}
