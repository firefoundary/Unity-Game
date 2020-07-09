using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float delay = 2;
    public float radius = 5;
    public float force = 200;
    public float speed = 5;
    public float reflectSpeed = 3;
    public int damage = 2;


    private Vector3 forceDirection;
    public GameObject splashEffect;
    public GameObject explosionParticles;

    private Vector3 grenadeDirection;
    private Vector3 lastDirection;

    float countdown;
    bool hasExploded = false;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;

        // normalizes shooting speed and direction
        grenadeDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        grenadeDirection.z = 0;
        grenadeDirection.Normalize();

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = grenadeDirection * speed;
    }

    // Update is called once per frame
    void Update()
    {
        lastDirection = rb.velocity;

        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded) {
            Explode();
            hasExploded = true;
        }
    }

    void Explode () {

        // show effect
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        GameObject splash = Instantiate(splashEffect, pos, transform.rotation);
        Destroy(splash, 10);
        Instantiate(explosionParticles, transform.position, transform.rotation);
        
 
        //Get nearby enemies
        Collider2D [] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D nearbyObject in colliders) {
            
            //explosive force
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null) {

                forceDirection = nearbyObject.transform.position - transform.position;
                forceDirection.Normalize();
                rb.AddForce(forceDirection * force, ForceMode2D.Impulse);
            
            }

            //damage enemy
            Enemy enemy = nearbyObject.GetComponent<Enemy>();
            if (enemy != null)
                enemy.TakeDamage(damage);

            //damage boss
            BossHealth boss = nearbyObject.GetComponent<BossHealth>();
                if (boss != null) 
                    boss.TakeDamage(damage);
    

        }

        // remove grenade
        Destroy(gameObject);
    }
    
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Enemy")) {
            Explode();
            hasExploded = true;
        }

        if (col.gameObject.CompareTag("PlayerBullet")) {
            Explode();
            hasExploded = true;
            Destroy(col.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            var direction = Vector3.Reflect(lastDirection.normalized, col.contacts[0].normal);

            rb.velocity = direction * reflectSpeed;
        }
    }

}
