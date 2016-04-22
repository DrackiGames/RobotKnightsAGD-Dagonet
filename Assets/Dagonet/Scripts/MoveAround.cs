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
	private VisorManager visorManager;

    public bool shouldWalk;
	public bool idleLookAround;
	public bool visorDown;
	public bool started;
    public bool shouldSpeakMedium;
	public bool visorCooldown;

	void Start () 
    {
        navMeshAgentForPlayer = player.GetComponent<NavMeshAgent>();
        playerAnimator = player.GetComponent<Animator>();
		CSM = GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>();
		visorManager = GameObject.FindGameObjectWithTag ("VisorManager").GetComponent<VisorManager> ();
        shouldWalk = false;
		visorDown = false;
		started = false;
        shouldSpeakMedium = true;
		visorCooldown = false;
		
		int rand = Random.Range(0, 2);
		if(rand == 0)
		{
			idleLookAround = true;
		}
		else
		{
			idleLookAround = false;
		}
	}
	
    void Update()
    {
        if (navMeshAgentForPlayer.hasPath)
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
		
		if(Input.GetKeyDown(KeyCode.V) && !visorCooldown && !playerAnimator.GetBool("shouldWalk"))
		{
			started = true;
            visorDown = !visorDown;
			visorManager.switchVisor(visorDown);
			StartCoroutine(visorCooldownProcess());
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
		
        if (canMove() && Input.GetMouseButtonDown(1) && !playerAnimator.GetBool("shouldTalkMedium"))
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = GameObject.Find(CSM.currentCamera).GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, layerMask))
            {
                captured = hit.transform;
                if (hit.collider.tag == "Ground")
                {
                    //Debug.Log("MOVE AROUND");
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

	private IEnumerator visorCooldownProcess()
	{
		visorCooldown = true;

		yield return new WaitForSeconds (1);

		visorCooldown = false;
	}

	private bool canMove()
	{
		bool able = true;

		if(visorCooldown)
		{
			return false;
		}
		if(GameObject.Find ("DialogueManager").GetComponent<DialogueManager>().choicesEnabled())
		{
			return false;
		}
		if(GameObject.Find ("Button Manager").GetComponent<PauseButtonScript>().isPaused())
		{
			return false;
		}
		if(GameObject.Find ("Tutorial Manager").GetComponent<Tutorial>().isTutorialUp())
		{
			return false;
		}
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
