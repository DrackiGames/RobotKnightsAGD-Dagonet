﻿using UnityEngine;
using System.Collections;

public class ModelReverseNormals : MonoBehaviour 
{
	void Start () 
	{
		Mesh mesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;

		Vector3[] normals = mesh.normals;
		for (int i = 0 ; i < normals.Length; i++)
        {
            normals[i] = -normals[i];
        }
				
		mesh.normals = normals;

        for (int m = 0; m < mesh.subMeshCount; m++)
        {
           int[] triangles = mesh.GetTriangles(m);
           for (int i = 0; i < triangles.Length; i += 3)
           {
               int temp = triangles[i + 0];
               triangles[i + 0] = triangles[i + 1];
               triangles[i + 1] = temp;
           }
           mesh.SetTriangles(triangles, m);
        }
	}
}
