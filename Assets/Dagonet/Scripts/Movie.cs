using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movie : MonoBehaviour 
{

    public MovieTexture movie;

	void Start ()
    {
        GetComponent<RawImage>().texture = movie;
        movie.Play();
	}
	
	void Update () 
    {
	
	}
}
