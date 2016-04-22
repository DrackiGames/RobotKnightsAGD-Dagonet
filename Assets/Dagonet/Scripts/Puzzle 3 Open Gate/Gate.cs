using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour 
{
	private bool shouldOpen;
	private Vector3 startingGatePosition;

	[SerializeField]
	private float gateOpenDistance;
	[SerializeField]
	private int gateID;
	
	void Start () 
	{
		shouldOpen = false;
		startingGatePosition = transform.position;
	}

	void Update () 
	{
		if(shouldOpen && gateID == 1 && Vector3.Distance(startingGatePosition, transform.position) < gateOpenDistance)
		{
			transform.Translate(Time.deltaTime * 2, 0, 0);
		}
		if(shouldOpen && gateID == 2 && Vector3.Distance(startingGatePosition, transform.position) < gateOpenDistance)
		{
			transform.Translate(0, Time.deltaTime * 2, 0);
		}
	}

	public void shouldGateOpen()
	{
		shouldOpen = true;
	}
}
