using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

//TO-DO:
//Make sure size of text adapts to screen size
//Add background to main area of menu
//Add options for each menu selection



public class buttonScript : MonoBehaviour
{
    #region Serialized variables
    [SerializeField]
	private Button mainMenuButton;
	[SerializeField]
	private Button newGameButton;
	[SerializeField]
	private Button loadGameButton;
	[SerializeField]
	private Button settingsButton;
	[SerializeField]
	private Button exitButton;
	[SerializeField]
	private Button newGameButtonCopy;
	[SerializeField]
	private Button loadGameButtonCopy;
	[SerializeField]
	private Button settingsButtonCopy;
	[SerializeField]
	private Canvas canvas;
    [SerializeField]
    private GameObject backgroundImage;
    [SerializeField]
    private GameObject playerNameLabel;
    [SerializeField]
    private GameObject playerNameText;
    [SerializeField]
    private GameObject playerNamePrompt;
    [SerializeField]
    private GameObject LoadGameSave1;
    [SerializeField]
    private GameObject LoadGameSave2;
    [SerializeField]
    private GameObject LoadGameSave3;
    [SerializeField]
    private GameObject LoadGameSave4;
    [SerializeField]
    private GameObject LoadGameSave5;
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
    [SerializeField]
    private GameObject GameManager;
    #endregion

    #region Variables
    bool lerpSet;
    bool buttonMoving;
    bool newState;
    Vector3 startPosition;
    Vector3 endPosition;
    float startTime;
    float totalDistanceToDestination;
    EButton selectedButton;
    EState menuState;
    #endregion

    #region Enums
    enum EButton
    {
        none,
        newGame,
        loadGame,
        settings,
        exit
    };

    enum EState
    {
        idleNoButtonSelected,
        idleButtonSelected,
        buttonSend,
        buttonReturn
    };
    #endregion

    void Start()
    {
        menuState = EState.idleNoButtonSelected;
        selectedButton = EButton.none;
        newState = false;
        backgroundImage.SetActive(false);
        playerNameLabel.SetActive(false);
        playerNameText.SetActive(false);
        playerNamePrompt.SetActive(false);
        LoadGameSave1.SetActive(false);
        LoadGameSave2.SetActive(false);
        LoadGameSave3.SetActive(false);
        LoadGameSave4.SetActive(false);
        LoadGameSave5.SetActive(false);
        SettingsVolumeLabel.SetActive(false);
        SettingsVolumeSlider.SetActive(false);
        SettingsSubtitlesLabel.SetActive(false);
        SettingsSubtitlesCheckbox.SetActive(false);
        SettingsQualityLabel.SetActive(false);
        SettingsQualityLabel2.SetActive(false);
        SettingsQualitySlider.SetActive(false);

        mainMenuButton.interactable = false;
        newGameButtonCopy.interactable = false;
        loadGameButtonCopy.interactable = false;
        settingsButtonCopy.interactable = false;
    }

    void Update()
	{
        switch (menuState)
        {
            case EState.idleNoButtonSelected:
                if (newState)
                {
                    mainMenuButton.interactable = false;
                    newGameButton.interactable = true;
                    loadGameButton.interactable = true;
                    settingsButton.interactable = true;
                    exitButton.interactable = true;
                    backgroundImage.SetActive(false);
                    newState = false;
                }
                break;
            case EState.idleButtonSelected:
                if (newState)
                {
                    mainMenuButton.interactable = true;
                    newGameButton.interactable = false;
                    loadGameButton.interactable = false;
                    settingsButton.interactable = false;
                    exitButton.interactable = false;
                    newState = false;
                }
                switch (selectedButton)
                {
                    case EButton.newGame:
                        playerNameLabel.SetActive(true);
                        playerNameText.SetActive(true);
                        playerNamePrompt.SetActive(true);

                        if (playerNameText.GetComponent<Text>().text.Length > 0 && !playerNamePrompt.activeInHierarchy)
                        {
                            playerNamePrompt.SetActive(true);
                        }
                        else if (playerNameText.GetComponent<Text>().text.Length == 0 && playerNamePrompt.activeInHierarchy)
                        {
                            playerNamePrompt.SetActive(false);
                        }
                        //Get Key Presses
                        if (isKeyPressed())
                        {
                            if (getKeyPressed() == "Backspace" && playerNameText.GetComponent<Text>().text.Length > 0)
                            {
                                playerNameText.GetComponent<Text>().text = playerNameText.GetComponent<Text>().text.Remove(playerNameText.GetComponent<Text>().text.Length - 1);
                            }
                            else if (getKeyPressed() == "Enter" && playerNameText.GetComponent<Text>().text.Length > 0)
                            {
                                Application.LoadLevelAsync(1);
                            }
                            else if (getKeyPressed() != "Backspace" && getKeyPressed() != "Enter")
                            {
                                playerNameText.GetComponent<Text>().text += getKeyPressed();
                            }
                        }
                        break;
                    case EButton.loadGame:
                        LoadGameSave1.SetActive(true);
                        LoadGameSave2.SetActive(true);
                        LoadGameSave3.SetActive(true);
                        LoadGameSave4.SetActive(true);
                        LoadGameSave5.SetActive(true);
                        break;
                    case EButton.settings:
                        SettingsVolumeLabel.SetActive(true);
                        SettingsVolumeSlider.SetActive(true);
                        SettingsSubtitlesLabel.SetActive(true);
                        SettingsSubtitlesCheckbox.SetActive(true);
                        SettingsQualityLabel.SetActive(true);
                        SettingsQualityLabel2.SetActive(true);
                        SettingsQualitySlider.SetActive(true);
                        break;
                }
                break;
            case EState.buttonSend:
                if (newState)
                {
                    mainMenuButton.interactable = false;
                    newGameButton.interactable = false;
                    loadGameButton.interactable = false;
                    settingsButton.interactable = false;
                    exitButton.interactable = false;
                    backgroundImage.SetActive(true);
                    newState = false;
                }
                float currentDuration = (Time.time - startTime) * 500;
                float journeyFraction = currentDuration / totalDistanceToDestination;
                if (journeyFraction < 1)
                {
                    switch (selectedButton)
                    {
                        case EButton.newGame:                            
                            newGameButtonCopy.GetComponent<RectTransform>().position = Vector3.Lerp(startPosition, endPosition, journeyFraction);
                            break;
                        case EButton.loadGame:
                            loadGameButtonCopy.GetComponent<RectTransform>().position = Vector3.Lerp(startPosition, endPosition, journeyFraction);
                            break;
                        case EButton.settings:
                            settingsButtonCopy.GetComponent<RectTransform>().position = Vector3.Lerp(startPosition, endPosition, journeyFraction);
                            break;
                    }
                }
                else
                {
                    switch (selectedButton)
                    {
                        case EButton.newGame:
                            newGameButtonCopy.GetComponent<RectTransform>().position = Vector3.Lerp(startPosition, endPosition, 1);
                            break;
                        case EButton.loadGame:
                            loadGameButtonCopy.GetComponent<RectTransform>().position = Vector3.Lerp(startPosition, endPosition, 1);
                            break;
                        case EButton.settings:
                            settingsButtonCopy.GetComponent<RectTransform>().position = Vector3.Lerp(startPosition, endPosition, 1);
                            break;
                    }
                    menuState = EState.idleButtonSelected;
                    newState = true;
                }               
                break;
            case EState.buttonReturn:
                if (newState)
                {
                    mainMenuButton.interactable = false;
                    newGameButton.interactable = false;
                    loadGameButton.interactable = false;
                    settingsButton.interactable = false;
                    exitButton.interactable = false;
                    newState = false;
                }
                currentDuration = (Time.time - startTime) * 500;
                journeyFraction = currentDuration / totalDistanceToDestination;
                if (journeyFraction < 1)
                {
                    switch (selectedButton)
                    {
                        case EButton.newGame:
                            newGameButtonCopy.GetComponent<RectTransform>().position = Vector3.Lerp(startPosition, endPosition, journeyFraction);
                            playerNameLabel.SetActive(false);
                            playerNameText.SetActive(false);
                            playerNamePrompt.SetActive(false);
                            playerNameText.GetComponent<Text>().text = "";
                            break;
                        case EButton.loadGame:
                            loadGameButtonCopy.GetComponent<RectTransform>().position = Vector3.Lerp(startPosition, endPosition, journeyFraction);
                            LoadGameSave1.SetActive(false);
                            LoadGameSave2.SetActive(false);
                            LoadGameSave3.SetActive(false);
                            LoadGameSave4.SetActive(false);
                            LoadGameSave5.SetActive(false);
                            break;
                        case EButton.settings:
                            settingsButtonCopy.GetComponent<RectTransform>().position = Vector3.Lerp(startPosition, endPosition, journeyFraction);
                            SettingsVolumeLabel.SetActive(false);
                            SettingsVolumeSlider.SetActive(false);
                            SettingsSubtitlesLabel.SetActive(false);
                            SettingsSubtitlesCheckbox.SetActive(false);
                            SettingsQualityLabel.SetActive(false);
                            SettingsQualityLabel2.SetActive(false);
                            SettingsQualitySlider.SetActive(false);
                            break;
                    }
                }
                else
                {
                    switch (selectedButton)
                    {
                        case EButton.newGame:
                            newGameButtonCopy.GetComponent<RectTransform>().position = Vector3.Lerp(startPosition, endPosition, 1);
                            break;
                        case EButton.loadGame:
                            loadGameButtonCopy.GetComponent<RectTransform>().position = Vector3.Lerp(startPosition, endPosition, 1);
                            break;
                        case EButton.settings:
                            settingsButtonCopy.GetComponent<RectTransform>().position = Vector3.Lerp(startPosition, endPosition, 1);
                            break;
                    }
                    menuState = EState.idleNoButtonSelected;
                    selectedButton = EButton.none;
                    newState = true;
                }  
                break;
        }
	}

    public void buttonClick(string buttonClicked)
    {
        if (menuState == EState.idleNoButtonSelected)
        {
            switch (buttonClicked)
            {
                case "New Game":
                    startPosition = newGameButton.GetComponent<RectTransform>().position;
                    endPosition = newGameButton.GetComponent<RectTransform>().position + new Vector3(103, 15.5f, 0);
                    startTime = Time.time;
                    totalDistanceToDestination = Vector3.Distance(startPosition, endPosition);
                    newState = true;
                    selectedButton = EButton.newGame;
                    menuState = EState.buttonSend;
                    //newGameButton.GetComponentInChildren<Text>().color = new Color(100.0f/255.0f, 200.0f/255.0f, 255.0f/255.0f);
                    break;
                case "Load Game":
                    startPosition = loadGameButton.GetComponent<RectTransform>().position;
                    endPosition = loadGameButton.GetComponent<RectTransform>().position + new Vector3(103, 31, 0);
                    startTime = Time.time;
                    totalDistanceToDestination = Vector3.Distance(startPosition, endPosition);
                    newState = true;
                    selectedButton = EButton.loadGame;
                    menuState = EState.buttonSend;
                    break;
                case "Settings":
                    startPosition = settingsButton.GetComponent<RectTransform>().position;
                    endPosition = settingsButton.GetComponent<RectTransform>().position + new Vector3(103, 46.5f, 0);
                    startTime = Time.time;
                    totalDistanceToDestination = Vector3.Distance(startPosition, endPosition);
                    newState = true;
                    selectedButton = EButton.settings;
                    menuState = EState.buttonSend;
                    break;
                case "Exit":
                    Application.Quit();
                    break;
            }
        }
        else if (menuState == EState.idleButtonSelected)
        {
            if (buttonClicked == "Main Menu")
            {
                switch (selectedButton)
                {
                    case EButton.newGame:
                        startPosition = newGameButton.GetComponent<RectTransform>().position + new Vector3(103, 15.5f, 0);
                        endPosition = newGameButton.GetComponent<RectTransform>().position;
                        startTime = Time.time;
                        totalDistanceToDestination = Vector3.Distance(startPosition, endPosition);
                    newState = true;
                        selectedButton = EButton.newGame;
                        menuState = EState.buttonReturn;
                        break;
                    case EButton.loadGame:
                        startPosition = loadGameButton.GetComponent<RectTransform>().position + new Vector3(103, 31, 0);
                        endPosition = loadGameButton.GetComponent<RectTransform>().position;
                        startTime = Time.time;
                        totalDistanceToDestination = Vector3.Distance(startPosition, endPosition);
                    newState = true;
                        selectedButton = EButton.loadGame;
                        menuState = EState.buttonReturn;
                        break;
                    case EButton.settings:
                        startPosition = settingsButton.GetComponent<RectTransform>().position + new Vector3(103, 46.5f, 0);
                        endPosition = settingsButton.GetComponent<RectTransform>().position;
                        startTime = Time.time;
                        totalDistanceToDestination = Vector3.Distance(startPosition, endPosition);
                    newState = true;
                        selectedButton = EButton.settings;
                        menuState = EState.buttonReturn;
                        break;
                }
            }
        }
    }

    private bool isKeyPressed()
    {
        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2))
        {
            return true;
        }
        return false;
    }

    private string getKeyPressed()
    {
        foreach (char c in Input.inputString)
        {
            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == ' ')
            {
                return c.ToString();
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            return "Backspace";
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            return "Enter";
        }
        return null;
    }

    public void changeQualitySettings()
    {
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
}
