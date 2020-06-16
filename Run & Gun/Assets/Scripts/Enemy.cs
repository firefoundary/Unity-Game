using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 60;
    public float startTimeBtwShots;
    public float attackRange = 5;

    public GameObject projectile;
    public GameObject effect;
    public GameObject bloodSplash;

    public SpriteRenderer body;
    public Color hurtColor;

    private Transform player;
    private float dist;
    private float timeBtwShots;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }
 

    void Update()
    {	
        dist = Vector3.Distance(player.position, transform.position);

        if (dist <= attackRange) {
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
    }
    
    public void TakeDamage(int damage)
    {	
        StartCoroutine(Flash());
        health -= damage;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y - 1, -8.8f);
        
        // death particles
        Instantiate(effect, position, Quaternion.identity);
        Instantiate(bloodSplash, position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    IEnumerator Flash() {
        body.color = hurtColor;
        yield return new WaitForSeconds(0.075f);
        body.color = Color.white;
    }
}
