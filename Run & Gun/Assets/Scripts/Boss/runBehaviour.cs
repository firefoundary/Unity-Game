using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runBehaviour : StateMachineBehaviour
{
    public float speed;
    public float attackRange;

    private float timer;
    public float minChargeTime;
    public float maxChargeTime;
    
    Transform player;
    Rigidbody2D rb;
    Boss boss;


    

    //start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       rb = animator.GetComponent<Rigidbody2D>();
       boss = animator.GetComponent<Boss>();

       timer = Random.Range(minChargeTime, maxChargeTime);

    }

    //update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange) 
        {
            animator.SetTrigger("Attack");
        } 

        if (timer <= 0) {
           animator.SetTrigger("Charge");
        }
        else {
           timer -= Time.deltaTime;
        }
    }

    //exit
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Charge");
        animator.ResetTrigger("Run");


    }

   
}
