using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Target : MonoBehaviour 
{
    public bool skinned;
    public bool overItem = false;
    public bool visorObject;
    public LayerMask layerMask;
    public string targetName;

    public VisorManager visorManager;
    public Image image;
    public Image mouseTip;

    //Events
    public InspectionEvent inspectionEvent;
    public InteractionEvent interactionEvent;
    //

    private Color startingColour;
    private Text itemDisplayText;

    void Start()
    {
        if(skinned)
        {
            startingColour = GetComponent<SkinnedMeshRenderer>().material.color;
        }
        else
        {
            startingColour = GetComponent<MeshRenderer>().material.color;
        }

        itemDisplayText = GameObject.FindGameObjectWithTag("ItemText").GetComponent<Text>();
        image.enabled = false;
        mouseTip.enabled = false;
    }

	void OnMouseOver()
    {
        if (((visorObject && visorManager.visorOn) || !visorObject) && ableToDoTheHighlighting())
        {
            overItem = true;
            if (skinned)
            {
                GetComponent<SkinnedMeshRenderer>().material.color = Color.white;
            }
            else
            {
                GetComponent<MeshRenderer>().material.color = Color.white;
            }

            itemDisplayText.text = targetName;
            GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>().highlight();
            image.enabled = true;
            image.rectTransform.localScale = new Vector3(itemDisplayText.text.Length + 1.2f, image.rectTransform.localScale.y, image.rectTransform.localScale.z);
            mouseTip.enabled = true;
        }
    }

    void OnMouseExit()
    {
        if (((visorObject && visorManager.visorOn) || !visorObject) && ableToDoTheHighlighting())
        {
            overItem = false;
            if (skinned)
            {
                GetComponent<SkinnedMeshRenderer>().material.color = startingColour;
            }
            else
            {
                GetComponent<MeshRenderer>().material.color = startingColour;
            }

            itemDisplayText.text = "";
            GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>().normal();
            image.enabled = false;
            mouseTip.enabled = false;
        }
    }

    private bool ableToDoTheHighlighting()
    {
        return !GameObject.Find("TerminalScreen").GetComponent<Terminal>().inUse;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && overItem && (((visorObject && visorManager.visorOn) || !visorObject) && ableToDoTheHighlighting()))
        {
            RaycastHit hit;
            if (Physics.Raycast(new Ray(transform.position + transform.forward * 0.5f, Vector3.down), out hit, 1000, layerMask))
            {
                if (hit.transform.tag == "Ground")
                {
                    GameObject.Find(GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>().currentCamera).GetComponent<MoveAround>().shouldWalk = true;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().destination = hit.point;

                    if (inspectionEvent != null)
                    {
                        resetItemTextCursorAndHint();
                        StartCoroutine(inspectionEvent.inspectionEvents());
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1) && overItem && (((visorObject && visorManager.visorOn) || !visorObject) && ableToDoTheHighlighting()))
        {
            RaycastHit hit;
            if (Physics.Raycast(new Ray(transform.position + transform.forward * 0.5f, Vector3.down), out hit, 1000, layerMask))
            {
                if (hit.transform.tag == "Ground")
                {
                    GameObject.Find(GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>().currentCamera).GetComponent<MoveAround>().shouldWalk = true;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().destination = hit.point;

                    if(interactionEvent != null)
                    {
                        resetItemTextCursorAndHint();
                        StartCoroutine(interactionEvent.interactionEvents());
                    }
                }
            }
        }
    }

    public void resetItemTextCursorAndHint()
    {
        if (skinned)
        {
            GetComponent<SkinnedMeshRenderer>().material.color = startingColour;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = startingColour;
        }

        itemDisplayText.text = "";
        GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>().normal();
        image.enabled = false;
        mouseTip.enabled = false;
    }
}
