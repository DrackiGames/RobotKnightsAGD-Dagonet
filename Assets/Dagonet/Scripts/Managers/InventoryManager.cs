using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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

    private List<string> inventoryList;
    int inventoryCount;

	void Start () 
    {
        inventoryList = new List<string>();
        inventoryList.Add("");
        inventoryList.Add("");
        inventoryList.Add("");
        inventoryList.Add("");
        inventoryCount = 0;
        addToInventory("detectiveItem1");
	}
	
	// Update is called once per frame
	void Update () 
    {
        int count = 0;
        foreach (Transform slot in inventorySlotTransforms)
        {
            string texture = inventoryList[count];
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

    public Sprite getSpriteNeeded(string par1ItemTextureIdentifier)
    {
        Sprite neededSprite = null;
        switch(par1ItemTextureIdentifier)
        {
            case "detectiveItem1": neededSprite = detectiveItem1; break;
            case "detectiveItem2": neededSprite = detectiveItem2; break;
            case "detectiveItem3": neededSprite = detectiveItem3; break;
            case "": neededSprite = empty; break;
        }

        return neededSprite;
    }

    public void addToInventory(string par1ItemTextureIdentifier)
    {
        int insertCount = 0;
        foreach(string item in inventoryList)
        {
            if(item == "")
            {
                break;
            }
            insertCount++;
        }
        inventoryList[insertCount] = par1ItemTextureIdentifier;
        inventoryCount++;
    }

    public void removeFromInventory(string par1ItemTextureIdentifier)
    {
        int removeCount = 0;
        foreach (string item in inventoryList)
        {
            if (item == par1ItemTextureIdentifier)
            {
                break;
            }
            removeCount++;
        }
        inventoryList[removeCount] = "";
        inventoryCount--;
    }
}
