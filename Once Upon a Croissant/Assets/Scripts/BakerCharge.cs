using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakerCharge : StateMachineBehaviour
{

    public float speed;
    public float chargeOffSet = 3;
    public float readyUpTime;
    private float rdyUpTime;

    Transform player;
    Rigidbody2D rb;
    ChargeEnemy enemy;

    private Vector2 target;
    private Vector2 newPos;
    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<ChargeEnemy>();

        enemy.LookAtPlayer();

        if (player.position.x > rb.position.x)
            target = new Vector2(player.position.x + chargeOffSet, rb.position.y);
        else 
            target = new Vector2(player.position.x - chargeOffSet, rb.position.y);

        rdyUpTime = readyUpTime;
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (rdyUpTime <= 0) {
            newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        else
            rdyUpTime -= Time.deltaTime;

        if (Vector2.Distance(rb.position, target) < 0.1) {
            animator.SetTrigger("Walk");
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("Charge");
       animator.ResetTrigger("Walk");

    }

  
}
