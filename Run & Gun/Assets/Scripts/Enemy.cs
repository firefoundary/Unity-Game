using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 60;
    public float startTimeBtwShots;
    public GameObject projectile;
    public GameObject effect;
    public GameObject bloodSplash;


    private Transform player;
    private float timeBtwShots;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }
 

    void Update()
    {	
    	// waits 2 seconds between each shot
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
		//enemy loses hp
        health -= damage;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        // can add death animation here
        Vector3 position = new Vector3(transform.position.x, transform.position.y - 1, -8.8f);
        Instantiate(effect, position, Quaternion.identity);
        Instantiate(bloodSplash, position, Quaternion.identity);
        Destroy(gameObject);
    }
    
}
