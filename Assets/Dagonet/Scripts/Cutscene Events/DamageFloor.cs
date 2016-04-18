using UnityEngine;
using System.Collections;

public class DamageFloor : MonoBehaviour 
{
    [SerializeField]
    private FraggedControllerC brokenFloor;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform officeLocation;
    [SerializeField]
    private CameraSwitchManager CSM;
    [SerializeField]
    private string sceneCamera1;
    [SerializeField]
    private string sceneCamera2;
    
    public bool fallen;
    public bool fallFinished;

	void Start () 
    {
	    fallen = false;
        fallFinished = false;
	}

    void Update()
    {
        if(fallen && !fallFinished)
        {
            Debug.Log("FALL");
            player.transform.Translate(new Vector3(0, -3 * Time.deltaTime, 0));
        }
    }

    void OnCollisionEnter(Collision par1Collision)
    {
        if (par1Collision.transform.tag == "MainCharacter" && !fallen)
        {
            Debug.Log("DAMAGE FLOOR");

            FraggedChildC[] children = brokenFloor.GetComponentsInChildren<FraggedChildC>();
            for (int i = 0; i < 10000; i++ )
            {
                int randChild = Random.Range(0, children.Length);
                children[randChild].Damage(50.0f);
            }

            fallen = true;

            transform.GetComponent<BoxCollider>().enabled = false;
            transform.GetComponent<MeshRenderer>().enabled = false;

            StartCoroutine(fallProcess());
        }
    }

    private IEnumerator fallProcess()
    {
        yield return new WaitForSeconds(1.5f);

        fallFinished = true;

        CSM.isFadingIn = false;

        yield return new WaitForSeconds(0.3f);

		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().Warp(officeLocation.position);

        string currentCamera = CSM.currentCamera;

        CSM.switchCamera(currentCamera, sceneCamera1);
        CSM.coupleCamera1 = sceneCamera1;
        CSM.coupleCamera2 = sceneCamera2;

        GameObject.Find(CSM.coupleCamera1).GetComponent<Camera>().enabled = true;

        yield return new WaitForSeconds(0.3f);

        CSM.isFadingIn = true;
		GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<NavMeshAgent>().ResetPath();
    }
    
}
