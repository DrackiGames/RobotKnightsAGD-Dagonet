using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FixItemText : MonoBehaviour 
{
    private Text itemText;

	void Start () 
    {
        itemText = GameObject.FindGameObjectWithTag("ItemText").GetComponent<Text>();

        itemText.transform.position = new Vector3(100.0f, 10.0f, 0.0f);
	}
	
	void Update () 
    {
	
	}
}
