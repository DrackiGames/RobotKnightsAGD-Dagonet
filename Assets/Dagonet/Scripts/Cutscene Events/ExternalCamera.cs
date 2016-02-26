﻿using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class ExternalCamera : MonoBehaviour 
{
    [SerializeField]
    private VisorManager visorManager;
    [SerializeField]
    private ColorCorrectionCurves colourChange;
    [SerializeField]
    private Text escapeText;
	
	void Update () 
    {
	    if(visorManager.visorOn && !colourChange.enabled)
        {
            colourChange.enabled = true;
        }
        if(!visorManager.visorOn && colourChange.enabled)
        {
            colourChange.enabled = false;
        }
	}
}