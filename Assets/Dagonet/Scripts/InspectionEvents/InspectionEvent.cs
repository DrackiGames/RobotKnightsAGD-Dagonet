using UnityEngine;
using System.Collections;

public class InspectionEvent : MonoBehaviour 
{
    public virtual IEnumerator inspectionEvents()
    {
        yield return new WaitForSeconds(0.0f);
    }
}
