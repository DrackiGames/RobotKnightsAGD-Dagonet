using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseAudioScript : MonoBehaviour {

    [SerializeField]
    private AudioSource soundEffectSource;
    [SerializeField]
    private Slider volumeSlider;

	void Start () 
    {
        
	}
	
	void Update () 
    {
        //Debug.Log("VALUE: " + volumeSlider.value + ", N VALUE: " + volumeSlider.normalizedValue);
	}

    public void changeVolume()
    {
        gameManager.Instance.changeGameVolume(volumeSlider.normalizedValue);
    }
}
