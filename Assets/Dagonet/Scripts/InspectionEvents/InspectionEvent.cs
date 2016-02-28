using UnityEngine;
using System.Collections;

public class InspectionEvent : MonoBehaviour 
{
    protected CameraSwitchManager CSM;
    protected AudioSource atPlayer;
    protected SubtitleManager subtitleManager;
    protected Animator playerAnimator;

    void Start()
    {
        CSM = GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>();
        atPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        subtitleManager = GameObject.FindGameObjectWithTag("SubtitleManager").GetComponent<SubtitleManager>();
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    public virtual IEnumerator inspectionEvents()
    {
        yield return new WaitForSeconds(0.0f);
    }

    public IEnumerator waitAndResetSubtitles(float par1LengthOfClip)
    {
        yield return new WaitForSeconds(par1LengthOfClip + 0.1f);

        GameObject.Find(CSM.currentCamera).GetComponent<MoveAround>().shouldTalkMediumProcess(false);
        subtitleManager.clearSubtitles();
    }
}
