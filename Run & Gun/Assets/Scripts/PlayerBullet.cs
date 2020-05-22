using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage = 20;
    // public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Destroy(gameObject, 3); //destroys bullets after 3 seconds
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Enemy enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        // can add bullet impact effect here
        //Destroy(gameObject);
    }
   
}