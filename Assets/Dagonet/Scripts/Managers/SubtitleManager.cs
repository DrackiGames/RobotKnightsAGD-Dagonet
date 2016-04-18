using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubtitleManager : MonoBehaviour 
{
    [SerializeField]
    private Text subtitleText;
	[SerializeField]
	private Color dagonetColour;
	[SerializeField]
	private Color detectiveColour;
	[SerializeField]
	private Color gangsterColour;
	[SerializeField]
	private Color leaderColour;

    public void updateSubtitles(string par1Subtitle)
    {
		if(gameManager.Instance.getSubtitlesEnabled())
		{
			subtitleText.text = par1Subtitle;
		}
		subtitleText.color = dagonetColour;
    }

	public void updateSubtitles(string par1Subtitle, string par2Type)
	{
		if(gameManager.Instance.getSubtitlesEnabled())
		{
			subtitleText.text = par1Subtitle;
		}

		switch(par2Type)
		{
			case "MainCharacter" : subtitleText.color = dagonetColour; break;
			case "Detective" : subtitleText.color = detectiveColour; break;
			case "Gangster" : subtitleText.color = gangsterColour; break;
			case "Leader" : subtitleText.color = leaderColour; break;
		}
	}

    public void clearSubtitles()
    {
        subtitleText.text = "";
    }
}
