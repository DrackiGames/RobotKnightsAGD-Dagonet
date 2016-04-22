using UnityEngine;
using System.Collections;

public class BatteryFixSpot : MonoBehaviour 
{	
	[SerializeField]
	private Transform battery;
	
	[SerializeField]
	private int batteryID;
	
	[SerializeField]
	private InventoryManager inventoryManager;
	
	[SerializeField]
	private Camera puzzle3Camera;
	
	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(1) && inventoryManager.hasGotItem("batteryItem" + batteryID))
		{
			battery.gameObject.SetActive(true);
			inventoryManager.removeFromInventory("batteryItem" + batteryID);
			Destroy(gameObject);
		}
	}
	
	void Update()
	{
		if(puzzle3Camera.enabled)
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
