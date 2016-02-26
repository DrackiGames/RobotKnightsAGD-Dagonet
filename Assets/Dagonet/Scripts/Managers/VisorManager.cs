using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class VisorManager : MonoBehaviour 
{
    public bool visorOn;

    private Text visorText;
    private CameraSwitchManager CSM;

	void Start () 
    {
        visorOn = false;
        visorText = GameObject.FindGameObjectWithTag("VisorText").GetComponent<Text>();
        CSM = GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>();
	}
	
	void Update () 
    {
	    if(Input.GetKeyDown(KeyCode.V))
        {
            visorOn = !visorOn;
        }

        if(visorOn)
        {
            visorText.text = "VISOR ENABLED";
            GameObject.Find(CSM.currentCamera).transform.GetComponent<ColorCorrectionCurves>().enabled = true;
        }
        else
        {
            visorText.text = "";
            GameObject.Find(CSM.currentCamera).transform.GetComponent<ColorCorrectionCurves>().enabled = false;
        }
	}
}
