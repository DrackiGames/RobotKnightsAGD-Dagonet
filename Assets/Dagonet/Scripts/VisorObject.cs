﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VisorObject : MonoBehaviour 
{
    public VisorManager visorManager;

    public Material onehundredfifty;
    public Material none;

    public Transform particleSystem;

    private Text itemText;

    void Start()
    {
        if (GetComponent<SkinnedMeshRenderer>())
        {
            GetComponent<SkinnedMeshRenderer>().material.color = none.color;
        }
        else
        {
            GetComponent<Renderer>().material.color = none.color;
        }

        itemText = GameObject.FindGameObjectWithTag("ItemText").GetComponent<Text>();
    }

	// Update is called once per frame
	void Update () 
    {
	    if(visorManager.visorOn)
        {
            if (GetComponent<SkinnedMeshRenderer>())
            {
                float lerpSkin = Mathf.PingPong(Time.fixedDeltaTime, 10.0f);
                GetComponent<SkinnedMeshRenderer>().material.color = Color.Lerp(GetComponent<SkinnedMeshRenderer>().material.color, onehundredfifty.color, lerpSkin);
            }
            else
            {
                float lerp = Mathf.PingPong(Time.fixedDeltaTime, 10.0f);
                GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, onehundredfifty.color, lerp);
            }

            particleSystem.gameObject.SetActive(true);
        }
        else
        {
            if (GetComponent<SkinnedMeshRenderer>())
            {
                float lerpSkin = Mathf.PingPong(Time.fixedDeltaTime, 10.0f);
                GetComponent<SkinnedMeshRenderer>().material.color = Color.Lerp(GetComponent<SkinnedMeshRenderer>().material.color, none.color, lerpSkin);
            }
            else
            {
                float lerp = Mathf.PingPong(Time.fixedDeltaTime, 10.0f);
                GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, none.color, lerp);
            }

            particleSystem.gameObject.SetActive(false);
        }
	}
}