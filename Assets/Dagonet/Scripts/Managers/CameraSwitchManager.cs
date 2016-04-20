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
    public TerminalCodePaper parchment;

	private bool switchForCameras;

	void Start () 
    {
		switchForCameras = false;
	}

    void Update()
    {
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			if(switchForCameras)
			{
				switchCamera(coupleCamera2, coupleCamera1);
				switchForCameras = false;
			}
			else
			{
				switchCamera(coupleCamera1, coupleCamera2);
				switchForCameras = true;
			}
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
        if(!mainTerminal.inUse && !parchment.inUse)
        {
            Camera findCamera1 = GameObject.Find(par1Camera1Name).GetComponent<Camera>();
            Camera findCamera2 = GameObject.Find(par2Camera2Name).GetComponent<Camera>();
            findCamera2.enabled = true;
            findCamera2.GetComponent<AudioListener>().enabled = true;
            findCamera1.enabled = false;
            findCamera1.GetComponent<AudioListener>().enabled = false;
            currentCamera = par2Camera2Name;
        }
    }
}
