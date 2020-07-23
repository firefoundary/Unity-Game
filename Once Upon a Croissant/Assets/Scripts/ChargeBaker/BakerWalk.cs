using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakerWalk : StateMachineBehaviour
{

    public float chargeRange;

    private bool scriptEnabled;
    private bool playerInRange;

    private Transform player;
    private Rigidbody2D rb;

    private bool canCharge;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();

        animator.GetComponent<PatrolCharge>().enabled = true;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        canCharge = animator.GetComponent<ChargeEnemy>().canCharge;


       if (canCharge && Vector2.Distance(player.position, rb.position) < chargeRange)
           animator.SetTrigger("Charge");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PatrolCharge>().enabled = false;
        animator.ResetTrigger("Walk");
        animator.ResetTrigger("Charge");
       
    }

   
} 
