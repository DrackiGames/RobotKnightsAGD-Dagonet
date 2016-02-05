using UnityEngine;
using System.Collections;

public class CharacterMoveAround : MonoBehaviour 
{
    private CameraSwitchManager CSM;
    private NavMeshAgent character;

    public LayerMask layerMask;

	// Use this for initialization
	void Start () 
    {
        CSM = GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>();
        character = transform.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = GameObject.Find(CSM.currentCamera).GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, layerMask))
            {
                if (hit.collider.tag == "Ground")
                {
                    Vector3 destination = hit.point;
                    character.destination = destination;
                }
            }
        }
	}
}
