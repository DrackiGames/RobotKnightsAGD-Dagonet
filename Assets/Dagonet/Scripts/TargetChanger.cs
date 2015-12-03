using UnityEngine;
using System.Collections;

public class TargetChanger : MonoBehaviour 
{
    public Camera currentCameraToLookAt;

    private CameraSwitchManager CSM;

    void Start()
    {
        CSM = GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>();
    }

	void Update () 
    {
        transform.LookAt(GameObject.Find(CSM.currentCamera).GetComponent<Camera>().transform);
	}
}
