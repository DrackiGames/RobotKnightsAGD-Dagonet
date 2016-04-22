using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuSettingsManager : MonoBehaviour 
{
    [SerializeField]
    private buttonScript buttonManager;
    [SerializeField]
    private audioScript audioManager;
    [SerializeField]
    private Slider volumeSlider;
    [SerializeField]
    private Slider qualitySlider;
    [SerializeField]
    private Toggle subtitlesCheckbox;

    void Start()
    {
		//Make the sliders and checkbox correct first
        volumeSlider.value = GameObject.Find("DataManager").GetComponent<DataManager>().getVolume();
        qualitySlider.value = GameObject.Find("DataManager").GetComponent<DataManager>().getQuality();
        subtitlesCheckbox.isOn = GameObject.Find("DataManager").GetComponent<DataManager>().getSubtitles();

        buttonManager.changeQualitySettings();
        audioManager.changeVolume();
        audioManager.setVolumeState();
    }
}
