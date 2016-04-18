using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour 
{
    [SerializeField]
    private GameObject PauseMenuObject;
    [SerializeField]
    private GameObject PauseMenuPanel;
    [SerializeField]
    private GameObject PromptObject;
    [SerializeField]
    private GameObject SettingsVolumeSlider;
    [SerializeField]
    private GameObject SettingsVolumeLabel;
    [SerializeField]
    private GameObject SettingsSubtitlesCheckbox;
    [SerializeField]
    private GameObject SettingsSubtitlesLabel;
    [SerializeField]
    private GameObject SettingsQualitySlider;
    [SerializeField]
    private GameObject SettingsQualityLabel;
    [SerializeField]
    private GameObject SettingsQualityLabel2;

    bool pauseMenuOpen;

	// Use this for initialization
	void Start () 
    {
        PauseMenuObject.SetActive(false);
        PauseMenuPanel.SetActive(false);
        PromptObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuObject.SetActive(!PauseMenuObject.activeInHierarchy);
            PauseMenuPanel.SetActive(!PauseMenuPanel.activeInHierarchy);
        }
	}

    public bool isPaused()
    {
        return PauseMenuObject.activeInHierarchy || PromptObject.activeInHierarchy;
    }

    public void changeQualitySettings()
    {
        gameManager.Instance.changeQualitySettings((int)SettingsQualitySlider.GetComponent<Slider>().value);
        QualitySettings.SetQualityLevel((int)SettingsQualitySlider.GetComponent<Slider>().value);

        switch (QualitySettings.GetQualityLevel())
        {
            case 0:
                SettingsQualityLabel2.GetComponent<Text>().text = "Fastest";
                break;
            case 1:
                SettingsQualityLabel2.GetComponent<Text>().text = "Fast";
                break;
            case 2:
                SettingsQualityLabel2.GetComponent<Text>().text = "Simple";
                break;
            case 3:
                SettingsQualityLabel2.GetComponent<Text>().text = "Good";
                break;
            case 4:
                SettingsQualityLabel2.GetComponent<Text>().text = "Beautiful";
                break;
            case 5:
                SettingsQualityLabel2.GetComponent<Text>().text = "Fantastic";
                break;
        }
    }

    public void setSubtitleState(bool par1Enabled)
    {
        gameManager.Instance.setSubtitlesEnabled(par1Enabled);
    }

    public void changeSubtitleState()
    {
        gameManager.Instance.changeSubtitlesState();
    }

    public void loadMainMenuPrompt()
    {
        PauseMenuObject.SetActive(false);
        PromptObject.SetActive(true);
    }

    public void loadMainMenuPromptAnswer(string answer)
    {
        if (answer == "Yes")
        {
            PromptObject.SetActive(false);
            Application.LoadLevelAsync(0);
        }
        else if (answer == "No")
        {
            PauseMenuObject.SetActive(true);
            PromptObject.SetActive(false);
        }
    }
}
