using UnityEngine;
using System.Collections;

public class TargetButton : MonoBehaviour 
{
    public bool isOver;

    void Start()
    {
        isOver = false;
    }
	
    void OnMouseEnter()
    {
        isOver = true;
    }

    void OnMouseExit()
    {
        isOver = false;
    }

	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetMouseButtonDown(1) && isOver)
        {
            if(transform.parent.GetComponent<ItemInspection>().IEvent != null)
            {
                transform.gameObject.SetActive(!transform.gameObject.activeInHierarchy);
                transform.gameObject.SetActive(!transform.gameObject.activeInHierarchy);
                StartCoroutine(transform.parent.GetComponent<ItemInspection>().IEvent.interactionEvents());
            }
        }
	}
}
