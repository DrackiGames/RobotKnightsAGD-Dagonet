using UnityEngine;
using System.Collections;

public class InteractionEvent : MonoBehaviour 
{
    protected CameraSwitchManager CSM;
    protected SubtitleManager subtitleManager;
	protected Animator playerAnimator;

    void Start()
    {
        CSM = GameObject.FindGameObjectWithTag("CameraSwitchManager").GetComponent<CameraSwitchManager>();
        subtitleManager = GameObject.FindGameObjectWithTag("SubtitleManager").GetComponent<SubtitleManager>();
		playerAnimator = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<Animator>();
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
