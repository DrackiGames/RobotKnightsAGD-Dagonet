using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryItem : System.IEquatable<InventoryItem>
{
	private string itemName;

	public InventoryItem(string par1ItemName)
	{
		itemName = par1ItemName;
	}

	public string getItemName()
	{
		return itemName;
	}

	public void setItemName(string par1ItemName)
	{
		itemName = par1ItemName;
	}

	public bool Equals(InventoryItem par1ItemName)
	{
		return false;
	}

	public bool Equals(string par1ItemName)
	{
		return par1ItemName.Equals (itemName);
	}
}

public class InventoryManager : MonoBehaviour 
{
    [SerializeField]
    private Transform inventory;
    [SerializeField]
    private Transform[] inventorySlotTransforms;

    [SerializeField]
    private Sprite empty;
    [SerializeField]
    private Sprite detectiveItem1;
    [SerializeField]
    private Sprite detectiveItem2;
    [SerializeField]
    private Sprite detectiveItem3;
	[SerializeField]
	private Sprite detectiveItem4;

    private List<InventoryItem> inventoryList;
    int inventoryCount;

	void Start () 
    {
        inventoryList = new List<InventoryItem>();
        inventoryList.Add(new InventoryItem("nothing"));
		inventoryList.Add(new InventoryItem("nothing"));
		inventoryList.Add(new InventoryItem("nothing"));
		inventoryList.Add(new InventoryItem("nothing"));
        inventoryCount = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        int count = 0;
        foreach (Transform slot in inventorySlotTransforms)
        {
            string texture = inventoryList[count].getItemName();
            slot.GetComponent<Image>().sprite = getSpriteNeeded(texture);
            count++;
        }

        if(Input.GetKey(KeyCode.I))
        {
            if(inventory.GetComponent<RectTransform>().position.x < 50)
            {
                inventory.GetComponent<RectTransform>().Translate(new Vector3(4, 0, 0));
            }
        }
        else
        {
            if (inventory.GetComponent<RectTransform>().position.x > -100)
            {
                inventory.GetComponent<RectTransform>().Translate(new Vector3(-4, 0, 0));
            }
        }
	}

	public bool hasGotItem(string par1ItemID)
	{
		bool found = false;
		foreach(InventoryItem item in inventoryList)
		{
			if(item.getItemName() == par1ItemID)
			{
				found = true;
				break;
			}
		}

		return found;
	}

    public Sprite getSpriteNeeded(string par1ItemTextureIdentifier)
    {
        Sprite neededSprite = null;
        switch(par1ItemTextureIdentifier)
        {
            case "detectiveItem1": neededSprite = detectiveItem1; break;
            case "detectiveItem2": neededSprite = detectiveItem2; break;
            case "detectiveItem3": neededSprite = detectiveItem3; break;
			case "detectiveItem4": neededSprite = detectiveItem4; break;
			case "nothing": neededSprite = empty; break;
        }

        return neededSprite;
    }

    public void addToInventory(string par1ItemTextureIdentifier)
    {
        int insertCount = 0;
		foreach(InventoryItem item in inventoryList)
        {
			if(item.getItemName() == "nothing")
            {
                break;
            }
            insertCount++;
        }
        inventoryList[insertCount].setItemName(par1ItemTextureIdentifier);
        inventoryCount++;
    }

    public void removeFromInventory(string par1ItemTextureIdentifier)
    {
		foreach(InventoryItem item in inventoryList)
		{
			if(item.getItemName() == par1ItemTextureIdentifier)
			{
				item.setItemName("nothing");
			}
		}
    }
}
