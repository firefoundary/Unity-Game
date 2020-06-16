using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletSpeed = 7;
    public float destroyTime = 5;
    public int damage = 20;

    private Transform player;
    private Vector3 bulletDirection;
    
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // normalizes shooting speed and direction
        bulletDirection = player.position - transform.position;
        bulletDirection.z = 0;
        bulletDirection.Normalize();
    }

    void Update()
    {
        transform.position += bulletDirection * bulletSpeed *  Time.deltaTime;
        Destroy(gameObject, destroyTime); //destroys bullets after destroyTime seconds
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // if bullet hits player, kill player, and destroy bullet
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
   
    void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }

        // can add bullet impact effect here
        //Destroy(gameObject);
    }
}