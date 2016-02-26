using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetManager : MonoBehaviour 
{
    private static List<Target> targetsInWorld = new List<Target>();

    public static void addTarget(Target par1Target)
    {
        targetsInWorld.Add(par1Target);
    }

    public static void removeTarget(Target par1Target)
    {
        targetsInWorld.Remove(par1Target);
    }

    public static void enableTargets()
    {
        foreach(Target t in targetsInWorld)
        {
            t.enabled = true;
        }
    }

    public static void disableTargets()
    {
        foreach (Target t in targetsInWorld)
        {
            t.enabled = false;
        }
    }
}
