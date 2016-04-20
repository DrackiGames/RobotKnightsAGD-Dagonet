using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class VisorManager : MonoBehaviour 
{
    public bool visorOn;

    private Text visorText;
    private CameraSwitchManager CSM;

	[SerializeField]
	private Camera[] sceneCameras;

	void Start () 
    {
        visorOn = false;
        visorText = GameObject.FindGameObjectWithTag("VisorText").GetComponent<Text>();
        CSM = GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>();
	}

	public void switchVisor(bool par1Mode)
	{
		if(par1Mode)
		{
			visorOn = true;
			visorText.text = "VISOR ENABLED";

			foreach(Camera sceneCamera in sceneCameras)
			{
				sceneCamera.transform.GetComponent<ColorCorrectionCurves>().enabled = true;
			}
		}
		else
		{
			visorOn = false;
			visorText.text = "";

			foreach(Camera sceneCamera in sceneCameras)
			{
				sceneCamera.transform.GetComponent<ColorCorrectionCurves>().enabled = false;
			}
		}
	}
}
