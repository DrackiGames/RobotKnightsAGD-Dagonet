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
        volumeSlider.value = gameManager.Instance.getGameVolume();
        qualitySlider.value = gameManager.Instance.getQualitySettings();
        subtitlesCheckbox.isOn = gameManager.Instance.getSubtitlesEnabled();

        buttonManager.changeQualitySettings();
        audioManager.changeVolume();
        audioManager.setVolumeState();
    }
}
