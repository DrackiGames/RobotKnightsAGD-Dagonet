using UnityEngine;
using System.Collections;

public class GateTerminal : MonoBehaviour 
{
	[SerializeField]
	private Gate[] mainGates;
	[SerializeField]
	private Transform[] batteries;
	[SerializeField]
	private Transform screen;
	[SerializeField]
	private Light screenLight;

	private bool completed;

	void Start () 
	{
		completed = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!completed && (batteries[0].gameObject.activeSelf || batteries[1].gameObject.activeSelf))
		{
			screen.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.5f, 0.0f);
			screenLight.color = new Color(1.0f, 0.5f, 0.0f);
		}
		if(!completed && batteries[0].gameObject.activeSelf && batteries[1].gameObject.activeSelf)
		{
			completed = true;
			screen.GetComponent<MeshRenderer>().material.color = Color.green;
			screenLight.color = Color.green;
			openGates();
		}
	}

	public void openGates()
	{
		foreach(Gate gate in mainGates)
		{
			gate.shouldGateOpen();
		}
	}
}
