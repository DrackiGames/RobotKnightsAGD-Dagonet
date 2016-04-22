using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseSettingsManager : MonoBehaviour 
{
    [SerializeField]
    private PauseButtonScript buttonManager;
    [SerializeField]
    private PauseAudioScript audioManager;
    [SerializeField]
    private Slider volumeSlider;
    [SerializeField]
    private Slider qualitySlider;
    [SerializeField]
    private Toggle subtitlesCheckbox;

	void Start () 
    {
        //Make the sliders and checkbox correct first
		Debug.Log (GameObject.Find ("DataManager").GetComponent<DataManager> ().getVolume ());
		volumeSlider.value = GameObject.Find("DataManager").GetComponent<DataManager>().getVolume();
		qualitySlider.value = GameObject.Find("DataManager").GetComponent<DataManager>().getQuality();
		subtitlesCheckbox.isOn = GameObject.Find("DataManager").GetComponent<DataManager>().getSubtitles();

        buttonManager.changeQualitySettings();
        audioManager.changeVolume();
	}
}
