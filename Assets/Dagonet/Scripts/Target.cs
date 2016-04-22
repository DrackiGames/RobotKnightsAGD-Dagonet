using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Target : MonoBehaviour 
{
    public bool overItem = false;
    public bool visorObject;
    public LayerMask layerMask;
    public string targetName;

    public bool parentTransform = false;
    public string directionAway;

    public VisorManager visorManager; 
    public Image image;
    public Image mouseTip;

    //Events
    public InspectionEvent inspectionEvent;
    public InteractionEvent interactionEvent;
    //

    private Color startingColour;
	public float startingOutlineWidth;
    public Text itemDisplayText;

    //Distance control
    public bool distanceControl;
    public float distanceFactor;
    //

	float otherComponents = 1.0f;
	float thickness = 1.0f;
	bool flip = false;
	bool thicknessFlip = false;

    void Start()
    {
        if (visorObject && GetComponent<SkinnedMeshRenderer>() != null) 
        {
            startingColour = GetComponent<SkinnedMeshRenderer>().material.color;
        }
        if(visorObject && GetComponent<MeshRenderer>() != null)
        {
            startingColour = GetComponent<MeshRenderer>().material.color;
        }

		if(!visorObject && GetComponent<SkinnedMeshRenderer>() != null)
		{
			startingOutlineWidth = GetComponent<SkinnedMeshRenderer>().material.GetFloat("_Outline");
		}
		else if(!visorObject && GetComponent<MeshRenderer>() != null)
		{
			startingOutlineWidth = GetComponent<MeshRenderer>().material.GetFloat("_Outline");
		}
		else
		{
			startingOutlineWidth = 0;
		}

        image.enabled = false;
        mouseTip.enabled = false;
    }

	void OnMouseOver()
    {
		if (canCheckItems() && !GameObject.Find("Button Manager").GetComponent<PauseButtonScript>().isPaused() && !GameObject.Find("Tutorial Manager").GetComponent<Tutorial>().isTutorialUp())
        {
            overItem = true;
            if (GetComponent<SkinnedMeshRenderer>() != null)
            {
				if(visorObject)
				{
					GetComponent<SkinnedMeshRenderer>().material.color = Color.white;
				}
				else
				{
					GetComponent<SkinnedMeshRenderer>().material.SetColor("_OutlineColour", new Color(1.0f, otherComponents, otherComponents));
					GetComponent<SkinnedMeshRenderer>().material.SetFloat("_Outline", startingOutlineWidth * thickness);
				}
            }
            if (GetComponent<MeshRenderer>() != null)
            {
				if(visorObject)
				{
					GetComponent<MeshRenderer>().material.color = Color.white;
				}
				else
				{
					GetComponent<MeshRenderer>().material.SetColor("_OutlineColour", new Color(1.0f, otherComponents, otherComponents));
					GetComponent<MeshRenderer>().material.SetFloat("_Outline", startingOutlineWidth * thickness);
				}
            }

            itemDisplayText.text = targetName;
            GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>().highlight();
            image.enabled = true;
            image.rectTransform.localScale = new Vector3((itemDisplayText.text.Length) * 1.25f, image.rectTransform.localScale.y, image.rectTransform.localScale.z);
            mouseTip.enabled = true;
        }
    }

    void OnMouseExit()
    {
        if (canCheckItems() && !GameObject.Find("Button Manager").GetComponent<PauseButtonScript>().isPaused() && !GameObject.Find("Tutorial Manager").GetComponent<Tutorial>().isTutorialUp())
        {
            overItem = false;
            if (GetComponent<SkinnedMeshRenderer>() != null)
            {
				if(visorObject)
				{
					GetComponent<SkinnedMeshRenderer>().material.color = startingColour;
				}
				else
				{
					GetComponent<SkinnedMeshRenderer>().material.SetColor("_OutlineColour", Color.black);
					GetComponent<SkinnedMeshRenderer>().material.SetFloat("_Outline", startingOutlineWidth);
				}
            }
            if (GetComponent<MeshRenderer>() != null)
            {
				if(visorObject)
				{
					GetComponent<MeshRenderer>().material.color = startingColour;
				}
				else
				{
					GetComponent<MeshRenderer>().material.SetColor("_OutlineColour", Color.black);
					GetComponent<MeshRenderer>().material.SetFloat("_Outline", startingOutlineWidth);
				}
            }

            itemDisplayText.text = "";
            GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>().normal();
            image.enabled = false;
            mouseTip.enabled = false;
        }
    }
	
    private bool ableToDoTheHighlighting()
    {
        return !GameObject.Find("TerminalScreen").GetComponent<Terminal>().inUse &&
            !GameObject.Find("Puzzle1PaperCamera").transform.parent.GetComponent<TerminalCodePaper>().inUse;
    }
	
    void Update()
    {
		if(flip)
		{
			if(otherComponents >= 1)
			{
				otherComponents = 1;
				flip = false;
			}
			otherComponents += Time.deltaTime * 2;
		}
		else
		{
			if(otherComponents <= 0)
			{
				otherComponents = 0;
				flip = true;
			}
			otherComponents -= Time.deltaTime * 2;
		}

		if(thicknessFlip)
		{
			if(thickness >= 2f)
			{
				thickness = 2f;
				thicknessFlip = false;
			}
			thickness += Time.deltaTime;
		}
		else
		{
			if(thickness <= 1)
			{
				thickness = 1;
				thicknessFlip = true;
			}

			thickness -= Time.deltaTime;
		}

		if (canCheckItems() && Input.GetMouseButtonDown(0) && overItem && (((visorObject && visorManager.visorOn) || !visorObject)))
        {
            if (inspectionEvent != null && !GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<Animator>().GetBool("shouldTalkMedium"))
            {
				if(!GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<Animator>().GetBool("shouldTalkMedium"))
                {
                    Debug.Log("INSPECT");
                    StartCoroutine(inspectionEvent.inspectionEvents());
                }
            }
        }

		if (canCheckItems() && Input.GetMouseButtonDown(1) && overItem && (((visorObject && visorManager.visorOn) || !visorObject)))
        {
			Debug.Log ("HI");
            RaycastHit hit;
            if (Physics.Raycast(new Ray((parentTransform ? transform.parent.position : transform.position) + getDirectionAway() * (distanceControl ? distanceFactor : 0.5f), Vector3.down), out hit, 1000, layerMask))
            {
				Debug.Log(hit.transform.name);
                if (hit.transform.tag == "Ground")
                {
					if (Vector3.Distance(GameObject.FindGameObjectWithTag("MainCharacter").transform.position, hit.transform.position) > 0.3f)
                    {
                        GameObject.Find(GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>().currentCamera).GetComponent<MoveAround>().shouldWalk = true;
						Debug.Log ("CHECK");
						GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().destination = hit.point;
                    }

                    if (interactionEvent != null)
                    {
						if(!GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<Animator>().GetBool("shouldTalkMedium"))
                        {
                            Debug.Log("MOVE AND INTERACT");
                            resetItemTextCursorAndHint();
                            StartCoroutine(interactionEvent.interactionEvents());
                        }
                    }
                }
            }
        }
    }

    public void resetItemTextCursorAndHint()
    {
        if (GetComponent<SkinnedMeshRenderer>() != null)
        {
			if(visorObject)
			{
				GetComponent<SkinnedMeshRenderer>().material.color = startingColour;
			}
			else
			{
				GetComponent<SkinnedMeshRenderer>().material.SetColor("_OutlineColour", Color.black);
			}
        }
        if (GetComponent<MeshRenderer>() != null)
        {
			if(visorObject)
			{
				GetComponent<MeshRenderer>().material.color = startingColour;
			}
			else
			{
				GetComponent<MeshRenderer>().material.SetColor("_OutlineColour", Color.black);
			}
        }

        itemDisplayText.text = "";
        GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>().normal();
        image.enabled = false;
        mouseTip.enabled = false;
    }

    public Vector3 getDirectionAway()
    {
        Vector3 newVector = Vector3.zero;
        switch(directionAway)
        {
            case "Y+" :
            {
                newVector = transform.up;
                break;
            }
            case "Y-":
            {
                newVector = transform.up * -1.0f;
                break;
            }
            case "X+":
            {
                newVector = transform.right;
                break;
            }
            case "X-":
            {
                newVector = transform.right * -1.0f;
                break;
            }
            case "Z+":
            {
                newVector = transform.forward;
                break;
            }
            case "Z-":
            {
                newVector = transform.forward * -1.0f;
                break;
            }
            default :
            {
                break;
            }
        }

        return newVector;
    }

	public void setInspectionEvent(InspectionEvent par1InspectionEvent)
	{
		inspectionEvent = par1InspectionEvent;
	}

	private bool canCheckItems()
	{
		bool able = true;

		if(GameObject.Find ("TerminalCamera").GetComponent<Camera>().enabled)
		{
			able = false;
		}
		if(GameObject.Find ("Puzzle1PaperCamera").GetComponent<Camera>().enabled)
		{
			able = false;
		}
		if(GameObject.Find ("Puzzle2FixDetectiveCamera").GetComponent<Camera>().enabled)
		{
			able = false;
		}
		if(GameObject.Find ("Puzzle3Camera").GetComponent<Camera>().enabled)
		{
			able = false;
		}
		if(GameObject.Find ("CutsceneCameraDetective").GetComponent<Camera>().enabled)
		{
			able = false;
		}
		if(GameObject.Find ("CutsceneCameraGangster").GetComponent<Camera>().enabled)
		{
			able = false;
		}
		if(GameObject.Find ("CutsceneCameraLeader").GetComponent<Camera>().enabled)
		{
			able = false;
		}

		return able;
	}
}
