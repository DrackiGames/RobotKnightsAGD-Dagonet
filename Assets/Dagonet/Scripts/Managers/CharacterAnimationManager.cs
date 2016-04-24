using UnityEngine;
using System.Collections;

public class CharacterAnimationManager : MonoBehaviour 
{
	[SerializeField]
	private Animator detectiveAnimator;
	[SerializeField]
	private Animator gangsterAnimator;
	[SerializeField]
	private Animator leaderAnimator;

	public void makeDetectiveIdle()
	{
		detectiveAnimator.SetBool ("idle", true);
		detectiveAnimator.SetBool ("talk1", false);
	}

	public void makeGangsterIdle()
	{
		gangsterAnimator.SetBool ("idle", true);
		gangsterAnimator.SetBool ("talk1", false);
	}

	public void makeLeaderIdle()
	{
		leaderAnimator.SetBool ("idle", true);
		leaderAnimator.SetBool ("talk1", false);
	} 

	public void makeDetectiveTalk()
	{
		StartCoroutine (makeDetectiveTalk1Process ());
	}

	public void makeGangsterTalk()
	{
		StartCoroutine (makeGangsterTalk1Process ());
	}

	public void makeLeaderTalk()
	{
		StartCoroutine (makeLeaderTalk1Process ());
	}

	private IEnumerator makeDetectiveTalk1Process()
	{
		detectiveAnimator.SetBool ("talk1", true);
		detectiveAnimator.SetBool ("idle", false);

		yield return new WaitForSeconds(2.167f);

		makeDetectiveIdle ();
	}

	private IEnumerator makeGangsterTalk1Process()
	{
		gangsterAnimator.SetBool ("talk1", true);
		gangsterAnimator.SetBool ("idle", false);
		
		yield return new WaitForSeconds(2.667f);
		
		makeGangsterIdle ();
	}

	private IEnumerator makeLeaderTalk1Process()
	{
		leaderAnimator.SetBool ("talk1", true);
		leaderAnimator.SetBool ("idle", false);
		
		yield return new WaitForSeconds(4f);
		
		makeLeaderIdle ();
	}
}
