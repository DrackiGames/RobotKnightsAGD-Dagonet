using UnityEngine;
using System.Collections;

public class OfficeCorridorDoorInteractionEvent : InteractionEvent
{
    public Transform corridorEntryPointLocation;

    public string sceneCamera1;
    public string sceneCamera2;

    public override IEnumerator interactionEvents()
    {
        yield return new WaitForSeconds(0.3f);

        CSM.isFadingIn = false;

        yield return new WaitForSeconds(0.3f);

        GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().Warp(corridorEntryPointLocation.position);

        string currentCamera = CSM.currentCamera;

        CSM.switchCamera(currentCamera, sceneCamera1);
        CSM.coupleCamera1 = sceneCamera1;
        CSM.coupleCamera2 = sceneCamera2;

        GameObject.Find(CSM.coupleCamera1).GetComponent<Camera>().enabled = true;

        yield return new WaitForSeconds(0.3f);

        CSM.isFadingIn = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().ResetPath();
    }
}
