using UnityEngine;
using UnityEngine.UI;
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

    public MeshCollider terminal;
    public Target target;

    public TerminalCodePaper codePaper;
	public PlaceParts puzzle2;

    public Transform[] doorLightSpheres;
	public Light[] doorLights;
	public Material greenMaterial;

    [SerializeField]
    private Text escapeText;

	void Start () 
    {
        codeCombination = "";
        for(int i = 0; i < 3; i++)
        {
            int r = Random.Range(1, 10);
            codeCombination += r.ToString();
        }

        codePaper.setupTerminalParchment(codeCombination);

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
        else
        {
			foreach(Transform sphere in doorLightSpheres)
			{
				sphere.GetComponent<MeshRenderer>().material = greenMaterial;
			}

            foreach(Light light in doorLights)
            {
                light.color = Color.green;
            }
        }

        if(inUse)
        {
            if (terminal.enabled)
            {
                terminal.enabled = false;
            }
            target.resetItemTextCursorAndHint();
            if(Input.GetKeyDown(KeyCode.Q))
            {
                StartCoroutine(exitTerminal());
            }

            if(!codePaper.inUse && !puzzle2.inUse)
            {
                escapeText.enabled = true;
                escapeText.GetComponent<Outline>().enabled = true;
            }
            
        }
        else
        {
            if(!terminal.enabled)
            {
                terminal.enabled = true;
            }

			if (!codePaper.inUse && !puzzle2.inUse)
            {
                escapeText.enabled = false;
                escapeText.GetComponent<Outline>().enabled = false;
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
		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();

        CameraSwitchManager CSM = GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>();
        CSM.isFadingIn = false;

        yield return new WaitForSeconds(0.3f);

        GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = true;
        GameObject.Find("TerminalCamera").GetComponent<Camera>().enabled = false;

		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();

        inUse = false;

        yield return new WaitForSeconds(0.3f);

        CSM.isFadingIn = true;
    }
}
