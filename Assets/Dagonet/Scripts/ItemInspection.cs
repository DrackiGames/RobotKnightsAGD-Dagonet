using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemInspection : MonoBehaviour 
{
    public Vector3 startingScale;
    public string displayText;
    public LayerMask layerMask;
    public Color selectColor;

    public bool overItem;
    public bool shouldCheck;

    public MoveAround moveAround;
    public bool shouldMovePlayer;

    public Terminal mainTerminal;

    //Events
    public InteractionEvent IEvent;

    //

    private Text itemText;
    private NavMeshAgent navMeshAgentForPlayer;
    private CameraSwitchManager CSM;

    void Start()
    {
        startingScale = GetComponent<SpriteRenderer>().transform.localScale;
        itemText = GameObject.FindGameObjectWithTag("ItemText").GetComponent<Text>();
        navMeshAgentForPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        overItem = false;
        selectColor = Color.white;
        shouldMovePlayer = false;
        CSM = GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>();

        foreach(SpriteRenderer g in GetComponentsInChildren<SpriteRenderer>())
        {
            if(g.transform != transform)
            {
                g.enabled = false;
            }
        }
    }

    void OnMouseEnter()
    {
        if(shouldCheck)
        {
            selectColor = Color.yellow;
            transform.GetComponent<SpriteRenderer>().material.color = selectColor;
            transform.GetComponent<SpriteRenderer>().transform.localScale = startingScale * 1.1f;

            itemText.text = displayText;

            overItem = true;
        }
    }

    void OnMouseExit()
    {
        if(shouldCheck)
        {
            selectColor = Color.white;
            transform.GetComponent<SpriteRenderer>().material.color = selectColor;
            transform.GetComponent<SpriteRenderer>().transform.localScale = startingScale;

            itemText.text = "";

            overItem = false;
        }
    }

    void Update()
    {
        moveAround = GameObject.Find(CSM.currentCamera).transform.GetComponent<MoveAround>();

        if (Input.GetMouseButtonDown(0) && overItem)
        {
            transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeInHierarchy);
            transform.GetChild(1).gameObject.SetActive(!transform.GetChild(1).gameObject.activeInHierarchy);
        }
        if(Input.GetMouseButtonDown(1) && overItem)
        {
            RaycastHit hit;
            if(Physics.Raycast(new Ray(transform.position + transform.forward * 0.5f, Vector3.down), out hit, 1000, layerMask))
            {
                if(hit.transform.tag == "Ground")
                {
                    navMeshAgentForPlayer.destination = hit.point;
                    shouldMovePlayer = true;
                }
            }
        }

        if(shouldMovePlayer)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("shouldWalk", true);
        }
    }
}
