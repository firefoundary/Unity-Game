using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runBehaviour : StateMachineBehaviour
{
    public float speed;
    public float attackRange;

    //charge
    public float chargeRange;

    //shoot
    private float timerShoot;
    public float minShootTime;
    public float maxShootTime;
    
    Transform player;
    Rigidbody2D rb;
    Boss boss;


    //start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();

        timerShoot = Random.Range(minShootTime, maxShootTime);

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

        //charge
        if (Vector2.Distance(player.position, rb.position) > chargeRange)
           animator.SetTrigger("Charge");

        //shoot
        if (timerShoot <= 0)
           animator.SetTrigger("Shoot");
        else
           timerShoot -= Time.deltaTime;
    }

    //exit
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Charge");
        animator.ResetTrigger("Run");
        animator.ResetTrigger("Shoot");



    }

   
}
