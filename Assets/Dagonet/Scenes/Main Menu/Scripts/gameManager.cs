using UnityEngine;
using System.Collections;

public class gameManager : Singleton<gameManager> 
{
    [SerializeField]
    private bool subtitlesEnabled;
    [SerializeField]
    private int graphicsQuality;
    [SerializeField]
    private float gameVolume;
    private bool started;

    void Awake()
    {
        subtitlesEnabled = true;
        graphicsQuality = QualitySettings.GetQualityLevel();
        gameVolume = 6f;
    }

    void OnLevelWasLoaded()
    {
        if(QualitySettings.GetQualityLevel() != graphicsQuality)
        {
            QualitySettings.SetQualityLevel(graphicsQuality);
        }

        if(Application.loadedLevel == 0)
        {
            subtitlesEnabled = true;
            graphicsQuality = QualitySettings.GetQualityLevel();
            gameVolume = 6f;
        }
    }

    public void appear()
    {

    }

    public bool getSubtitlesEnabled()
    {
        return subtitlesEnabled;
    }

    public void setSubtitlesEnabled(bool par1Enabled)
    {
        subtitlesEnabled = par1Enabled;
    }

    public void changeSubtitlesState()
    {
        subtitlesEnabled = !subtitlesEnabled;
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
