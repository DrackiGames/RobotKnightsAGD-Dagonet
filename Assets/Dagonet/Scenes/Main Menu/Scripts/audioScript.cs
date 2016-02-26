using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class audioScript : MonoBehaviour {

    
    [SerializeField]
    public Image volumeToggleImage;
    [SerializeField]
    private Sprite volumeMuteSprite;
    [SerializeField]
    private Sprite volumeLowSprite;
    [SerializeField]
    private Sprite volumeMediumSprite;
    [SerializeField]
    private Sprite volumeHighSprite;
    [SerializeField]
    private AudioSource soundEffectSource;
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private Slider volumeSlider;

    private float gameVolume;
    private EVolumeState volumeState;

    enum EVolumeState
    {
        mute,
        low,
        medium,
        high
    }

	// Use this for initialization
	void Start () 
    {
        gameVolume = 0.6f;
        volumeState = EVolumeState.medium;
	    volumeToggleImage.GetComponent<Image>().sprite = volumeMediumSprite;
        soundEffectSource.volume = 0.6f;
        musicSource.volume = 0.6f;
        
	}

    public void changeVolumeState()
    {
        switch (volumeState)
        {
            case EVolumeState.mute:
                gameVolume = 0.3f;
                volumeState = EVolumeState.low;
                volumeToggleImage.GetComponent<Image>().sprite = volumeLowSprite;
                soundEffectSource.volume = 0.3f;
                musicSource.volume = 0.3f;
                volumeSlider.normalizedValue = 0.3f;
                break;
            case EVolumeState.low:
                gameVolume = 0.6f;
                volumeState = EVolumeState.medium;
                volumeToggleImage.GetComponent<Image>().sprite = volumeMediumSprite;
                soundEffectSource.volume = 0.6f;
                musicSource.volume = 0.6f;
                volumeSlider.normalizedValue = 0.6f;
                break;
            case EVolumeState.medium:
                gameVolume = 1.0f;
                volumeState = EVolumeState.high;
                volumeToggleImage.GetComponent<Image>().sprite = volumeHighSprite;
                soundEffectSource.volume = 1.0f;
                musicSource.volume = 1.0f;
                volumeSlider.normalizedValue = 1.0f;
                break;
            case EVolumeState.high:
                gameVolume = 0.0f;
                volumeState = EVolumeState.mute;
                volumeToggleImage.GetComponent<Image>().sprite = volumeMuteSprite;
                soundEffectSource.volume = 0.0f;
                musicSource.volume = 0.0f;
                volumeSlider.normalizedValue = 0.0f;
                break;
        }

        GameObject.Find("Game Manager").GetComponent<gameManager>().changeGameVolume(gameVolume);
    }

    public void playClickEffect()
    {
        if (!soundEffectSource.isPlaying)
           soundEffectSource.Play();
    }

    public void changeVolume()
    {
        gameVolume = (float)(volumeSlider.value / 10);

        if (gameVolume == 0)
        {
            volumeState = EVolumeState.mute;
            volumeToggleImage.GetComponent<Image>().sprite = volumeMuteSprite;
            soundEffectSource.volume = 0.0f;
            musicSource.volume = 0.0f;
        }
        else if (gameVolume > 0 && gameVolume <= 0.5f)
        {
            volumeState = EVolumeState.low;
            volumeToggleImage.GetComponent<Image>().sprite = volumeLowSprite;
            soundEffectSource.volume = gameVolume;
            musicSource.volume = gameVolume;
        }
        else if (gameVolume > 0.5f && gameVolume <= 0.9f)
        {
            volumeState = EVolumeState.medium;
            volumeToggleImage.GetComponent<Image>().sprite = volumeMediumSprite;
            soundEffectSource.volume = gameVolume;
            musicSource.volume = gameVolume;
        }
        else if (gameVolume == 1.0f)
        {
            volumeState = EVolumeState.high;
            volumeToggleImage.GetComponent<Image>().sprite = volumeHighSprite;
            soundEffectSource.volume = gameVolume;
            musicSource.volume = gameVolume;
        }
    }

    public void testFunction()
    {
        Debug.LogError("Test");
    }
}
