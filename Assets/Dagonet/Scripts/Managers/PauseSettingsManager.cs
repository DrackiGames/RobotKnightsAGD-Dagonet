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
        volumeSlider.normalizedValue = gameManager.Instance.getGameVolume();
        qualitySlider.value = gameManager.Instance.getQualitySettings();
        subtitlesCheckbox.isOn = gameManager.Instance.getSubtitlesEnabled();

        buttonManager.changeQualitySettings();
        audioManager.changeVolume();
	}
}
