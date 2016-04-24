using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	private bool atEndOfGame;

	void Start()
	{
		atEndOfGame = false;
	}

	void OnTriggerEnter(Collider par1OtherCollider)
	{
		if (par1OtherCollider.tag == "MainCharacter")
		{
			atEndOfGame = true;
		}
	}

	public bool isEndOfGame()
	{
		return atEndOfGame;
	}
}
