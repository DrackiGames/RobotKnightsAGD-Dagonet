using UnityEngine;
using System.Collections;

public class InteractionEvent : MonoBehaviour 
{
    protected CameraSwitchManager CSM;
    protected AudioSource atPlayer;
    protected SubtitleManager subtitleManager;

    void Start()
    {
        CSM = GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>();
        atPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        subtitleManager = GameObject.FindGameObjectWithTag("SubtitleManager").GetComponent<SubtitleManager>();
    }

    public virtual IEnumerator interactionEvents()
    {
        yield return new WaitForSeconds(0.0f);
    }

    public IEnumerator waitAndResetSubtitles(float par1LengthOfClip)
    {
        yield return new WaitForSeconds(par1LengthOfClip + 0.1f);

        subtitleManager.clearSubtitles();
    }
}
