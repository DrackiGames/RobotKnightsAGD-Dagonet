using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class ExternalCamera : MonoBehaviour 
{
    [SerializeField]
    private VisorManager visorManager;
    [SerializeField]
    private Text escapeText;
	
	void Update () 
    {
	    if(visorManager.visorOn && !GetComponent<ColorCorrectionCurves>().enabled)
        {
            GetComponent<ColorCorrectionCurves>().enabled = true;
        }
        if (!visorManager.visorOn && GetComponent<ColorCorrectionCurves>().enabled)
        {
            GetComponent<ColorCorrectionCurves>().enabled = false;
        }
	}
}
