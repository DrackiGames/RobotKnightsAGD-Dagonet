using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FixVisorText : MonoBehaviour
{
    private Text itemText;

    void Start()
    {
        itemText = GameObject.FindGameObjectWithTag("VisorText").GetComponent<Text>();

        itemText.transform.position = new Vector3(100.0f, Screen.height - 30.0f, 0.0f);
    }

    void Update()
    {

    }
}
