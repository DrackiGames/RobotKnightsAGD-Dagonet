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
    private Text itemDisplayText;

    //Distance control
    public bool distanceControl;
    public float distanceFactor;
    //

    private TargetManager targetManager;

    void Start()
    {
        if (GetComponent<SkinnedMeshRenderer>() != null) 
        {
            startingColour = GetComponent<SkinnedMeshRenderer>().material.color;
        }
        if(GetComponent<MeshRenderer>() != null)
        {
            startingColour = GetComponent<MeshRenderer>().material.color;
        }
        if (GetComponent<SpriteRenderer>() != null)
        {
            startingColour = GetComponent<SpriteRenderer>().material.color;
        }

        itemDisplayText = GameObject.FindGameObjectWithTag("ItemText").GetComponent<Text>();
        image.enabled = false;
        mouseTip.enabled = false;

        TargetManager.addTarget(this);
    }

	void OnMouseOver()
    {
        if (((visorObject && visorManager.visorOn) || !visorObject))
        {
            overItem = true;
            if (GetComponent<SkinnedMeshRenderer>() != null)
            {
                GetComponent<SkinnedMeshRenderer>().material.color = Color.white;
            }
            if (GetComponent<MeshRenderer>() != null)
            {
                GetComponent<MeshRenderer>().material.color = Color.white;
            }
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().material.color = Color.white;
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
        if (((visorObject && visorManager.visorOn) || !visorObject))
        {
            overItem = false;
            if (GetComponent<SkinnedMeshRenderer>() != null)
            {
                GetComponent<SkinnedMeshRenderer>().material.color = startingColour;
            }
            if (GetComponent<MeshRenderer>() != null)
            {
                GetComponent<MeshRenderer>().material.color = startingColour;
            }
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().material.color = startingColour;
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
        //if (Input.GetMouseButtonDown(0) && overItem && (((visorObject && visorManager.visorOn) || !visorObject) && ableToDoTheHighlighting()))
        if (Input.GetMouseButtonDown(0) && overItem && (((visorObject && visorManager.visorOn) || !visorObject)))
        {
            //RaycastHit hit;
            //if (Physics.Raycast(new Ray((parentTransform ? transform.parent.position : transform.position) + getDirectionAway() * (distanceControl ? distanceFactor : 0.5f), Vector3.down), out hit, 1000, layerMask))
            //{
            //    if (hit.transform.tag == "Ground")
            //    {
            //        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, hit.transform.position) > 0.3f)
            //        {
            //            GameObject.Find(GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>().currentCamera).GetComponent<MoveAround>().shouldWalk = true;
            //            GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().destination = hit.point;
            //        }

            //        if (inspectionEvent != null)
            //        {
            //            Debug.Log("MOVE AND INSPECT");
            //            StartCoroutine(inspectionEvent.inspectionEvents());
            //        }
            //    }
            //}

            if (inspectionEvent != null)
            {
                Debug.Log("INSPECT");
                StartCoroutine(inspectionEvent.inspectionEvents());
            }
        }

        //if (Input.GetMouseButtonDown(1) && overItem && (((visorObject && visorManager.visorOn) || !visorObject) && ableToDoTheHighlighting()))
        if (Input.GetMouseButtonDown(1) && overItem && (((visorObject && visorManager.visorOn) || !visorObject)))
        {
            RaycastHit hit;
            if (Physics.Raycast(new Ray((parentTransform ? transform.parent.position : transform.position) + getDirectionAway() * (distanceControl ? distanceFactor : 0.5f), Vector3.down), out hit, 1000, layerMask))
            {
                if (hit.transform.tag == "Ground")
                {
                    if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, hit.transform.position) > 0.3f)
                    {
                        GameObject.Find(GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>().currentCamera).GetComponent<MoveAround>().shouldWalk = true;
                        GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().destination = hit.point;
                    }

                    if(interactionEvent != null)
                    {
                        Debug.Log("MOVE AND INTERACT");
                        resetItemTextCursorAndHint();
                        StartCoroutine(interactionEvent.interactionEvents());
                    }
                }
            }
        }
    }

    public void resetItemTextCursorAndHint()
    {
        if (GetComponent<SkinnedMeshRenderer>() != null)
        {
            GetComponent<SkinnedMeshRenderer>().material.color = startingColour;
        }
        if (GetComponent<MeshRenderer>() != null)
        {
            GetComponent<MeshRenderer>().material.color = startingColour;
        }
        if (GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().material.color = startingColour;
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
                newVector = transform.up;
                break;
            }
            case "Z-":
            {
                newVector = transform.up * -1.0f;
                break;
            }
            default :
            {
                break;
            }
        }

        return newVector;
    }
}
