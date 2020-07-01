using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : StateMachineBehaviour
{
    // public GameObject bulletPrefab;

    // private Transform player;
    // private Vector3 bulletDirection;

    // private Vector3 pos;

    // public float startTimeBtwShots;
    // private float timeBtwShots;

    private float timer;
    public float StartTimer;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // player = GameObject.FindGameObjectWithTag("Player").transform;
        // pos = animator.gameObject.transform.position;

        // bulletDirection = player.position - pos;
        // bulletDirection.z = 0;
        // bulletDirection.Normalize();

        timer = StartTimer;
       
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // if (timeBtwShots <= 0) {
        //     GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);

        //     timeBtwShots = startTimeBtwShots;
        //     timer -= Time.deltaTime;
        // }
        // else 
        //     timeBtwShots -= Time.deltaTime;

        if (timer <= 0)
           animator.SetTrigger("Run");
        else   
            timer -= Time.deltaTime;

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
