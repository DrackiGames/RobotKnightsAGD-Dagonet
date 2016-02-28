using UnityEngine;
using System.Collections;

public class MoveAround : MonoBehaviour 
{
    public Transform player;
    public Transform lookAtTarget;
    public Transform captured;
    public float cameraShiftUp;
    public LayerMask layerMask;

    private NavMeshAgent navMeshAgentForPlayer;
    private Animator playerAnimator;
    private CameraSwitchManager CSM;

    public bool shouldWalk;
	public bool idleLookAround;
	public bool visorDown;
	public bool started = false;
    public bool shouldSpeakMedium;

	void Start () 
    {
        navMeshAgentForPlayer = player.GetComponent<NavMeshAgent>();
        playerAnimator = player.GetComponent<Animator>();
        shouldWalk = false;
		visorDown = false;
        shouldSpeakMedium = true;
		started = false;
		
		int rand = Random.Range(0, 2);
		if(rand == 0)
		{
			idleLookAround = true;
		}
		else
		{
			idleLookAround = false;
		}
		
        CSM = GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>();
	}
	
    void Update()
    {
        if (shouldWalk)
        {
            playerAnimator.SetBool("shouldWalk", true);
        }

        if (!navMeshAgentForPlayer.hasPath)
        {
			shouldWalk = false;
            playerAnimator.SetBool("shouldWalk", false);
			
			int rand = Random.Range(0, 2);
			if(rand == 0)
			{
				playerAnimator.SetBool("lookAround", true);
			}
			else
			{
				playerAnimator.SetBool("lookAround", false);
			}
        }

        //if(Vector3.Distance(navMeshAgentForPlayer.transform.position, navMeshAgentForPlayer.destination) < 0.05f)
        //{
        //    navMeshAgentForPlayer.destination = navMeshAgentForPlayer.transform.position;
        //}

        //if (!shouldWalk)
        //{
        //    playerAnimator.SetBool("shouldWalk", false);
        //}
		
		if(Input.GetKeyDown(KeyCode.V))
		{
			started = true;
            visorDown = !visorDown;
		}
		
		if(visorDown)
		{
			playerAnimator.SetBool("visorDown", true);
			playerAnimator.SetBool("visorUp", false);
		}
        else
        {
            playerAnimator.SetBool("visorDown", false);
            playerAnimator.SetBool("visorUp", true);
        }
		
        if (Input.GetMouseButtonDown(1) && !playerAnimator.GetBool("shouldTalkMedium"))
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = GameObject.Find(CSM.currentCamera).GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, layerMask))
            {
                captured = hit.transform;
                if (hit.collider.tag == "Ground")
                {
                    Debug.Log("MOVE AROUND");
                    Vector3 destination = hit.point;
                    navMeshAgentForPlayer.destination = destination;
					shouldWalk = true;
                }
            }
        }

        transform.LookAt(lookAtTarget.position + new Vector3(0, cameraShiftUp, 0));
    }

    public void shouldTalkMediumProcess(bool par1ShouldTalkMedium)
    {
        playerAnimator.SetBool("shouldTalkMedium", par1ShouldTalkMedium);
    }
}
