using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : StateMachineBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 7;
    public float destroyTime = 5;

    private Transform player;
    private Vector3 bulletDirection;

    private Vector3 pos;

    public float startTimeBtwShots;
    private float timeBtwShots;

    private float timer;
    public float minTime;
    public float maxTime;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);

        player = GameObject.FindGameObjectWithTag("Player").transform;
        pos = animator.gameObject.transform.position;

        bulletDirection = player.position - pos;
        bulletDirection.z = 0;
        bulletDirection.Normalize();
       
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timeBtwShots <= 0) {
            GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
            bullet.transform.position += bulletDirection * bulletSpeed *  Time.deltaTime;
            Destroy(bullet, destroyTime);

            timeBtwShots = startTimeBtwShots;
            timer -= Time.deltaTime;
        }
        else 
            timeBtwShots -= Time.deltaTime;

        if (timer <= 0)
           animator.SetTrigger("Run");
        else   
            timer -= Time.deltaTime;

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
