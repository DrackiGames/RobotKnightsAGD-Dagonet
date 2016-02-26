using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubtitleManager : MonoBehaviour 
{
    [SerializeField]
    private Text subtitleText;

    public void updateSubtitles(string par1Subtitle)
    {
        if(GameObject.Find("Game Manager").GetComponent<gameManager>().getSubtitlesEnabled())
        {
            subtitleText.text = par1Subtitle;
        }
    }

    public void clearSubtitles()
    {
        subtitleText.text = "";
    }
}
