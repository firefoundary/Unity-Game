using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBehaviour : StateMachineBehaviour
{

    private GameObject p;
    private PlayerMovement player;
    
    //start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       p = GameObject.FindGameObjectWithTag("Player");
       
    }

    //update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = p.GetComponent<PlayerMovement>();

        if (!player.dialogueFreeze) {
            animator.SetTrigger("Start");
        }
            
    }

    //exit
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    
}
