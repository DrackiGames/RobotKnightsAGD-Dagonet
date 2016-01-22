using UnityEngine;
using System.Collections;

public class CutSceneEvent : MonoBehaviour
{
    public virtual IEnumerator cutSceneEvents()
    {
        yield return new WaitForSeconds(0.0f);
    }
}

