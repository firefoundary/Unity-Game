using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float delay = 2;
    public float radius = 5;
    public float force = 200;
    public float grenadeSpeed = 5;
    public int damage = 20;

    private Vector3 forceDirection;
    public GameObject explosionEffect;

    private Vector3 grenadeDirection;

    float countdown;
    bool hasExploded = false;
    bool thrown = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;

        // normalizes shooting speed and direction
        grenadeDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        grenadeDirection.z = 0;
        grenadeDirection.Normalize();

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(grenadeDirection * grenadeSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded) {
            Explode();
            hasExploded = true;
        }
    }

    void Explode () {

        // show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

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
            if (enemy != null) {

                enemy.TakeDamage(damage);

            }
        }

        // remove grenade
        Destroy(gameObject);
    }
}
