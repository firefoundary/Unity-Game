using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // public Rigidbody2D rb;
    public float speed;
    private Transform player;
    private Vector2 target;
    
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // if bullet hits player, kill player, and destroy bullet
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
   
}