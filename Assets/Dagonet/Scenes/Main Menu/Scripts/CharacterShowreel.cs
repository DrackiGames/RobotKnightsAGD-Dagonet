using UnityEngine;
using System.Collections;

public class CharacterShowreel : MonoBehaviour {

	[SerializeField]
	private Transform[] showreelCollection;

	private int showingCharacter;

	void Start () 
	{
		showingCharacter = 0;
	}

	float counter = 0;
	void Update () 
	{
		counter += Time.deltaTime * 4;
		Debug.Log (counter);
		
		if(counter >= 20)
		{
			counter = 0;
			setNewCharacter();
		}
		
		for(int i = 0; i < showreelCollection.Length; i++)
		{
			if(i != showingCharacter)
			{
				if(showreelCollection[i].GetComponent<SkinnedMeshRenderer>() != null)
				{
					Color currentColor = showreelCollection[i].GetComponent<SkinnedMeshRenderer>().material.color;
					if(currentColor.a > 0)
					{
						showreelCollection[i].GetComponent<SkinnedMeshRenderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, currentColor.a - Time.deltaTime * 4);
					}
				}
				if(showreelCollection[i].GetComponent<MeshRenderer>() != null)
				{
					Color currentColor = showreelCollection[i].GetComponent<MeshRenderer>().material.color;
					if(currentColor.a > 0)
					{
						showreelCollection[i].GetComponent<MeshRenderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, currentColor.a - Time.deltaTime * 4);
					}
				}
			}
			else
			{
				if(showreelCollection[i].GetComponent<SkinnedMeshRenderer>() != null)
				{
					Color currentColor = showreelCollection[i].GetComponent<SkinnedMeshRenderer>().material.color;
					if(currentColor.a < 1)
					{
						showreelCollection[i].GetComponent<SkinnedMeshRenderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, currentColor.a + Time.deltaTime * 4);
					}
				}
				if(showreelCollection[i].GetComponent<MeshRenderer>() != null)
				{
					Color currentColor = showreelCollection[i].GetComponent<MeshRenderer>().material.color;
					if(currentColor.a < 1)
					{
						showreelCollection[i].GetComponent<MeshRenderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, currentColor.a + Time.deltaTime * 4);
					}
				}
			}
		}


	}

	private void setNewCharacter()
	{
		if(showingCharacter == 3)
		{
			showingCharacter = 0;
		}
		else
		{
			showingCharacter++;
		}
	}

	public void disableCharacters()
	{
		foreach(Transform character in showreelCollection)
		{
			if(character.gameObject.activeSelf)
			{
				character.gameObject.SetActive(false);
			}
		}
	}

	public void enableCharacters()
	{
		foreach(Transform character in showreelCollection)
		{
			if(!character.gameObject.activeSelf)
			{
				character.gameObject.SetActive(true);
			}
		}
	}
}
