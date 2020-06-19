using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBehaviour : StateMachineBehaviour
{

    private float timer;
    public float minTime;
    public float maxTime;

    //start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       timer = Random.Range(minTime, maxTime);
    }

    //update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (timer <= 0) {
           animator.SetTrigger("Run");
       }
       else {
           timer -= Time.deltaTime;
       }
    }

    //exit
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    
}
