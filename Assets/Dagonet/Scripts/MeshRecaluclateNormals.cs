using UnityEngine;
using System.Collections;

public class MeshRecaluclateNormals : MonoBehaviour 
{
	void Start()
	{
		GetComponent<MeshFilter> ().mesh.RecalculateNormals ();
	}
}
