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
        SettingsContainer sc = SettingsContainer.loadSettings(Application.dataPath + "\\Resources\\Settings.xml");
        sc.gameSettings[0].volumeValue = (int)(gameManager.Instance.getGameVolume() * 10);
        sc.saveSettings(Application.dataPath + "\\Resources\\Settings.xml");
    }
}
