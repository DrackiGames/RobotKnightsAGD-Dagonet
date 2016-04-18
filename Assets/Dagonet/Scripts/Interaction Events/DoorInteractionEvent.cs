using UnityEngine;
using System.Collections;

public class DoorInteractionEvent : InteractionEvent 
{
    public Transform corridorLocation;
    public Light entryLight;

    public string sceneCamera1;
    public string sceneCamera2;

    public override IEnumerator interactionEvents()
    {
        if(entryLight.color == Color.green)
        {
            yield return new WaitForSeconds(0.3f);

            CSM.isFadingIn = false;

            yield return new WaitForSeconds(0.3f);

			GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().Warp(corridorLocation.position);

            string currentCamera = CSM.currentCamera;

            CSM.switchCamera(currentCamera, sceneCamera1);
            CSM.coupleCamera1 = sceneCamera1;
            CSM.coupleCamera2 = sceneCamera2;

            GameObject.Find(CSM.coupleCamera1).GetComponent<Camera>().enabled = true;

            yield return new WaitForSeconds(0.3f);

            CSM.isFadingIn = true;
			GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();
        }
    }
}
