using UnityEngine;
using System.Collections;

public class MainMenuDisplay : MonoBehaviour 
{
	[SerializeField]
	private bool zTurn;

	void Update()
	{
		if(zTurn)
		{
			transform.Rotate (0, 0, Time.deltaTime * 10);
		}
		else
		{
			transform.Rotate (0, Time.deltaTime * 10, 0);
		}
	}
}
