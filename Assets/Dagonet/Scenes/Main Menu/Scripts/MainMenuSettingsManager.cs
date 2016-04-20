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
        SettingsContainer sc = SettingsContainer.loadSettings(Application.dataPath + "\\Resources\\Settings.xml");
        //Make the sliders and checkbox correct first
        volumeSlider.value = sc.gameSettings[0].volumeValue;
        qualitySlider.value = sc.gameSettings[0].qualityValue;
        subtitlesCheckbox.isOn = sc.gameSettings[0].subtitlesEnabled;
        //volumeSlider.value = gameManager.Instance.getGameVolume();
        //qualitySlider.value = gameManager.Instance.getQualitySettings();
        //subtitlesCheckbox.isOn = gameManager.Instance.getSubtitlesEnabled();

        buttonManager.changeQualitySettings();
        audioManager.changeVolume();
        audioManager.setVolumeState();
    }
}
