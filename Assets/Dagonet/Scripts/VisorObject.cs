using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VisorObject : MonoBehaviour 
{
    public VisorManager visorManager;

    public Material onehundredfifty;
    public Material none;

    public SpriteRenderer target;
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

        target.material.color = Color.clear;
        target.GetComponent<ItemInspection>().shouldCheck = false;
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
            target.GetComponent<ItemInspection>().shouldCheck = true;

            if(target)
            {
                float lerpTarget = Mathf.PingPong(Time.fixedDeltaTime, 10.0f);
                target.material.color = Color.Lerp(target.material.color, target.GetComponent<ItemInspection>().selectColor, lerpTarget);
            }
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

            if(target)
            {
                if (target.GetComponent<ItemInspection>().overItem)
                {
                    target.GetComponent<ItemInspection>().overItem = false;
                    target.GetComponent<ItemInspection>().selectColor = Color.white;
                    target.transform.localScale = target.GetComponent<ItemInspection>().startingScale;
                    itemText.text = "";
                }

                target.GetComponent<ItemInspection>().shouldCheck = false;

                float lerpTarget = Mathf.PingPong(Time.fixedDeltaTime, 10.0f);
                target.material.color = Color.Lerp(target.material.color, Color.clear, lerpTarget);
            }

            target.transform.GetChild(0).gameObject.SetActive(false);
            target.transform.GetChild(1).gameObject.SetActive(false);
        }
	}
}
