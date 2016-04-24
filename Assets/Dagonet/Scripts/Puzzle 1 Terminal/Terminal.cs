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

    public TerminalCodePaper codePaper;
	public PlaceParts puzzle2;

    public Transform[] doorLightSpheres;
	public Light[] doorLights;
	public Material greenMaterial;

	[SerializeField]
	private QuestTextManager questTextManager;
	private bool crackFinished;

	void Start () 
    {
        codeCombination = "";
        for(int i = 0; i < 3; i++)
        {
            int r = Random.Range(1, 10);
            codeCombination += r.ToString();
        }

		Debug.Log ("Terminal code combination: " + codeCombination);

        codePaper.setupTerminalParchment(codeCombination);

        cracked = false;
        inUse = false;
		crackFinished = false;
	}
	
	void Update () 
    {
        if(!cracked)
        {
            if (inputCode.Length == 3 && !isCodeCorrect(inputCode))
			{
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

			if(!crackFinished)
			{
				crackFinished = true;
				questTextManager.popUpQuest("SUCCESS! CHECK OUTSIDE THE TERMINAL ROOM!");
			}
        }

        if(inUse)
        {
            GetComponentInParent<Target>().resetItemTextCursorAndHint();
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

	private IEnumerator quest()
	{
		yield return new WaitForSeconds(3.75f);
		
		questTextManager.fadeIn = false;
	}
}
