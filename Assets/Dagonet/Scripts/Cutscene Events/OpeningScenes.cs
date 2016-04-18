using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpeningScenes : MonoBehaviour 
{
	[SerializeField]
	private AudioClip music;

	[SerializeField]
	private Transform blackImage;

	[SerializeField]
	private Transform[] images;

	[SerializeField]
	private Text[] creditsText;

	[SerializeField]
	private CameraSwitchManager CSM;

	void Start () 
	{
		Cursor.visible = false;

		StartCoroutine (openingSceneProcess ());
	}

	private IEnumerator openingSceneProcess()
	{
		GameObject.Find(CSM.currentCamera).GetComponent<Camera>().enabled = false;
		GameObject.Find("OpeningCamera1").GetComponent<Camera>().enabled = true;

		GameObject.Find ("OpeningCamera1").GetComponent<AudioSource> ().PlayOneShot (music);

		yield return new WaitForSeconds(1.0f);

		creditsText [0].gameObject.SetActive (true);

		yield return new WaitForSeconds(4.0f);

		creditsText [0].gameObject.SetActive (false);
		creditsText [1].gameObject.SetActive (true);

		yield return new WaitForSeconds(4.0f);

		creditsText [1].gameObject.SetActive (false);

		yield return new WaitForSeconds(1.0f);

		blackImage.gameObject.SetActive (false);
		images [0].gameObject.SetActive (true);
		creditsText [2].gameObject.SetActive (true);
	}
}
