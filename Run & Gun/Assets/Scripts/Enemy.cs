using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 60;
    public float speed;
    public float stoppingDistance;
    private Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }


    void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
            Die();
    }

    void Die()
    {
        // can add death animation here
        Destroy(gameObject);
    }
    
}
