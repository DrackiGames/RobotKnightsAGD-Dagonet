using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraSwitchManager : MonoBehaviour 
{
    public string currentCamera;
    public bool isFadingIn = false;
    public Image blackImage;

    public string coupleCamera1;
    public string coupleCamera2;

    public Terminal mainTerminal;

	void Start () 
    {
        
	}

    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            switchCamera(coupleCamera1, coupleCamera2);
        }
        if(Input.GetKey(KeyCode.Alpha2))
        {
            switchCamera(coupleCamera2, coupleCamera1);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            isFadingIn = !isFadingIn;
        }

        if(!isFadingIn && blackImage.color.a < 255)
        {
            blackImage.color = new Color(0, 0, 0, blackImage.color.a + (10 * Time.deltaTime));
        }
        if (isFadingIn && blackImage.color.a > 0)
        {
            blackImage.color = new Color(0, 0, 0, blackImage.color.a - (10 * Time.deltaTime));
        }
    }

    public void switchCamera(string par1Camera1Name, string par2Camera2Name)
    {
        if(!mainTerminal.inUse)
        {
            Camera findCamera1 = GameObject.Find(par1Camera1Name).GetComponent<Camera>();
            Camera findCamera2 = GameObject.Find(par2Camera2Name).GetComponent<Camera>();
            findCamera2.enabled = true;
            findCamera1.enabled = false;
            currentCamera = par2Camera2Name;
        }
    }
}
