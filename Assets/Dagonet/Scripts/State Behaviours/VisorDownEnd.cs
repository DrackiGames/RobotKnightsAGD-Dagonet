using UnityEngine;
using System.Collections;

public class VisorDownEnd : StateMachineBehaviour 
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<Animator>().SetBool("visorDown", false);
    }
}
