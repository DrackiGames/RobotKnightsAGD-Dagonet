using UnityEngine;
using System.Collections;

public class AudioChanger : MonoBehaviour 
{
    private gameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<gameManager>();
    }

	void Update()
    {
        if(GetComponent<AudioSource>().volume != gameManager.getGameVolume())
        {
            GetComponent<AudioSource>().volume = gameManager.getGameVolume();
        }
    }
}
