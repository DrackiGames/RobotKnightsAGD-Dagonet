using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

    private bool subtitlesEnabled;
    private int graphicsQuality;
    private float gameVolume;

    void Awake()
    {
        DontDestroyOnLoad(this);
        subtitlesEnabled = true;
        graphicsQuality = QualitySettings.GetQualityLevel();
        gameVolume = 0.6f;
    }
    void Update()
    {
        
    }

    public bool getSubtitlesEnabled()
    {
        return subtitlesEnabled;
    }

    public void changeSubtitlesState()
    {
        if (subtitlesEnabled)
            subtitlesEnabled = false;
        else
            subtitlesEnabled = true;

        QualitySettings.SetQualityLevel(1);
    }

    public int getQualitySettings()
    {
        return graphicsQuality;
    }

    public void changeQualitySettings(int _qualitySetting)
    {
        graphicsQuality = _qualitySetting;
    }

    public float getGameVolume()
    {
        return gameVolume;
    }

    public void changeGameVolume(float _gameVolume)
    {
        gameVolume = _gameVolume;
    }
}
