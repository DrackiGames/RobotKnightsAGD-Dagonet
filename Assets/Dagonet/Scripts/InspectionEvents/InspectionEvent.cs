using UnityEngine;
using System.Collections;

public class InspectionEvent : MonoBehaviour 
{
    public virtual IEnumerator interactionEvents()
    {
        yield return new WaitForSeconds(0.0f);
    }
}
