﻿using UnityEngine;
using System.Collections;

public class FixSpot : MonoBehaviour 
{
	[SerializeField]
	private Transform visorPiece;

	[SerializeField]
	private Transform realPiece;

	[SerializeField]
	private int spotID;

	[SerializeField]
	private InventoryManager inventoryManager;

	[SerializeField]
	private Camera puzzle2Camera;

	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(1) && inventoryManager.hasGotItem("detectiveItem" + spotID))
		{
			visorPiece.gameObject.SetActive(false);
			realPiece.gameObject.SetActive(true);
			inventoryManager.removeFromInventory("detectiveItem" + spotID);
			Destroy(gameObject);
		}
	}

	void Update()
	{
		if(puzzle2Camera.enabled)
		{
			if(!GetComponent<SphereCollider>().enabled)
			{
				GetComponent<SphereCollider>().enabled = true;
			}
			if(!GetComponent<MeshRenderer>().enabled)
			{
				GetComponent<MeshRenderer>().enabled = true;
			}
		}
		else
		{
			if(GetComponent<SphereCollider>().enabled)
			{
				GetComponent<SphereCollider>().enabled = false;
			}
			if(GetComponent<MeshRenderer>().enabled)
			{
				GetComponent<MeshRenderer>().enabled = false;
			}
		}
	}
}