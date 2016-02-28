using UnityEngine;
using System.Collections;

public class cursorChanger : MonoBehaviour 
{
	void Update () 
    {
        if (Input.GetMouseButton(0))
        {
            GameObject.Find("CursorManager").GetComponent<CursorManager>().highlight();
        }
        if (!Input.GetMouseButton(0))
        {
            GameObject.Find("CursorManager").GetComponent<CursorManager>().normal();
        }
	}
}
