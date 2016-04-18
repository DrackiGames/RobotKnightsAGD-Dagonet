using UnityEngine;
using System.Collections;

public class AudioChanger : MonoBehaviour 
{
	void Update()
    {
        if(GetComponent<AudioSource>().volume != gameManager.Instance.getGameVolume())
        {
            GetComponent<AudioSource>().volume = gameManager.Instance.getGameVolume();
        }
    }
}
