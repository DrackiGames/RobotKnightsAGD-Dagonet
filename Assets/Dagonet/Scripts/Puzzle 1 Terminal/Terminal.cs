using UnityEngine;
using System.Collections;

public class Terminal : MonoBehaviour 
{
    public string codeCombination;
    public string inputCode;

    public Transform acceptedOrRejected;
    public Sprite accepted, rejected;

    public TextMesh displayText;

    public bool cracked;
    public bool inUse;

    public string previousCamera;

	void Start () 
    {
        codeCombination = "";
        for(int i = 0; i < 3; i++)
        {
            int r = Random.Range(1, 10);
            codeCombination += r.ToString();
        }

        cracked = false;
        inUse = false;
	}
	
	void Update () 
    {
        if(!cracked)
        {
            if (inputCode.Length == 3 && !isCodeCorrect(inputCode))
            {
                //inputCode = "";
                //acceptedOrRejected.GetComponent<SpriteRenderer>().sprite = rejected;
                StartCoroutine(reject());
            }
            if (inputCode.Length == 3 && isCodeCorrect(inputCode))
            {
                displayText.color = Color.green;
                acceptedOrRejected.GetComponent<SpriteRenderer>().sprite = accepted;
                cracked = true;
            }

            displayText.text = inputCode;
        }

        if(inUse)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                StartCoroutine(exitTerminal());
            }
        }
	}

    IEnumerator reject()
    {
        acceptedOrRejected.GetComponent<SpriteRenderer>().sprite = rejected;
        displayText.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        displayText.color = Color.black;

        inputCode = "";
    }

    private bool isCodeCorrect(string par1InputString)
    {
        if(codeCombination.Length >= 0)
        {
            return par1InputString.Equals(codeCombination);
        }
        else
        {
            return false;
        }
    }

    private IEnumerator exitTerminal()
    {
        CameraSwitchManager CSM = GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>();
        CSM.isFadingIn = false;

        yield return new WaitForSeconds(0.3f);

        GameObject.Find("SceneCamera").GetComponent<Camera>().enabled = true;
        GameObject.Find("TerminalCamera").GetComponent<Camera>().enabled = false;

        inUse = false;

        yield return new WaitForSeconds(0.3f);

        CSM.isFadingIn = true;
    }
}
