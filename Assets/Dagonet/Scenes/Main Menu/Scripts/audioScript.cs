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
        //if(gameManager.Instance.getGameVolume() == 0)
        //{
        //    volumeState = EVolumeState.mute;
        //}
        //else if (gameManager.Instance.getGameVolume() > 0 && gameManager.Instance.getGameVolume() <= 0.3)
        //{
        //    volumeState = EVolumeState.low;
        //}
        //else if (gameManager.Instance.getGameVolume() > 0.3 && gameManager.Instance.getGameVolume() <= 0.6)
        //{
        //    volumeState.m
        //}
        //else
        //{

        //}
        
	    //volumeToggleImage.GetComponent<Image>().sprite = volumeMediumSprite;
	}

    void Update()
    {
        Debug.Log("VALUE: " + volumeSlider.value + ", N VALUE: " + volumeSlider.normalizedValue);
    }

    public void setVolumeState()
    {
        if(gameManager.Instance.getGameVolume() == 0)
        {
            volumeState = EVolumeState.mute;
            volumeToggleImage.GetComponent<Image>().sprite = volumeMuteSprite;
        }
        else if (gameManager.Instance.getGameVolume() > 0 && gameManager.Instance.getGameVolume() <= 0.3)
        {
            volumeState = EVolumeState.low;
            volumeToggleImage.GetComponent<Image>().sprite = volumeLowSprite;
        }
        else if (gameManager.Instance.getGameVolume() > 0.3 && gameManager.Instance.getGameVolume() <= 0.6)
        {
            volumeState = EVolumeState.medium;
            volumeToggleImage.GetComponent<Image>().sprite = volumeMediumSprite;
        }
        else
        {
            volumeState = EVolumeState.high;
            volumeToggleImage.GetComponent<Image>().sprite = volumeHighSprite;
        }

    }

    public void changeVolumeState()
    {
        switch (volumeState)
        {
            case EVolumeState.mute:
                volumeState = EVolumeState.low;
                volumeToggleImage.GetComponent<Image>().sprite = volumeLowSprite;
                soundEffectSource.volume = 0.3f;
                musicSource.volume = 0.3f;
                volumeSlider.normalizedValue = 0.3f;
                break;
            case EVolumeState.low:
                volumeState = EVolumeState.medium;
                volumeToggleImage.GetComponent<Image>().sprite = volumeMediumSprite;
                soundEffectSource.volume = 0.6f;
                musicSource.volume = 0.6f;
                volumeSlider.normalizedValue = 0.6f;
                break;
            case EVolumeState.medium:
                volumeState = EVolumeState.high;
                volumeToggleImage.GetComponent<Image>().sprite = volumeHighSprite;
                soundEffectSource.volume = 1.0f;
                musicSource.volume = 1.0f;
                volumeSlider.normalizedValue = 1.0f;
                break;
            case EVolumeState.high:
                volumeState = EVolumeState.mute;
                volumeToggleImage.GetComponent<Image>().sprite = volumeMuteSprite;
                soundEffectSource.volume = 0.0f;
                musicSource.volume = 0.0f;
                volumeSlider.normalizedValue = 0.0f;
                break;
        }

        gameManager.Instance.changeGameVolume(volumeSlider.normalizedValue);
    }

    public void playClickEffect()
    {
        if (!soundEffectSource.isPlaying)
           soundEffectSource.Play();
    }

    public void changeVolume()
    {
        float gameVolume = (float)(volumeSlider.normalizedValue);

        if (gameVolume == 0)
        {
            volumeState = EVolumeState.mute;
            volumeToggleImage.GetComponent<Image>().sprite = volumeMuteSprite;
            soundEffectSource.volume = 0.0f;
            musicSource.volume = 0.0f;
        }
        else if (gameVolume > 0 && gameVolume <= 0.3f)
        {
            volumeState = EVolumeState.low;
            volumeToggleImage.GetComponent<Image>().sprite = volumeLowSprite;
            soundEffectSource.volume = gameVolume;
            musicSource.volume = gameVolume;
        }
        else if (gameVolume > 0.3f && gameVolume <= 0.6f)
        {
            volumeState = EVolumeState.medium;
            volumeToggleImage.GetComponent<Image>().sprite = volumeMediumSprite;
            soundEffectSource.volume = gameVolume;
            musicSource.volume = gameVolume;
        }
        else
        {
            volumeState = EVolumeState.high;
            volumeToggleImage.GetComponent<Image>().sprite = volumeHighSprite;
            soundEffectSource.volume = gameVolume;
            musicSource.volume = gameVolume;
        }

        gameManager.Instance.changeGameVolume(volumeSlider.normalizedValue);
    }
}
