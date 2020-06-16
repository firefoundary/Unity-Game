using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Vector3 bulletDirection;
    public float bulletSpeed = 10;
    public int damage = 20;
    public float destroyTime = 3;
    // public Rigidbody2D rb;

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
        transform.position += bulletDirection * bulletSpeed *  Time.deltaTime;

        Destroy(gameObject, destroyTime); //destroys bullets after destroyTime seconds
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