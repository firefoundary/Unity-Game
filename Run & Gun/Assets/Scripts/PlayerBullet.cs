using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Vector3 bulletDirection;
    private float angle;

    public float bulletSpeed = 10;
    public float damage;
    public float destroyTime = 3;
    
    public GameObject collisionEffect;

    // Start is called before the first frame update
    void Start()
    {
        // normalizes shooting speed and direction
        bulletDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        bulletDirection.z = 0;
        bulletDirection.Normalize();
    }

    void Update()
    {
        //bullet angle and position 
        angle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position += bulletDirection * bulletSpeed *  Time.deltaTime;

        Destroy(gameObject, destroyTime); //destroys bullets after destroyTime seconds
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground") || col.CompareTag("EnemyBullet")) {

            if (col.CompareTag("EnemyBullet"))
                Instantiate(collisionEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
            return;
        }

        Enemy enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log("shoot with" + damage + "damage");
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        } 
        
        // destroy bullet if collides with terrain b

        // can add bullet impact effect here
        //Destroy(gameObject);
    }
    
   
}