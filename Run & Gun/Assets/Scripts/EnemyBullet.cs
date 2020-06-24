using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletSpeed = 7;
    public float destroyTime = 5;
    public int damage = 1;
    
    public float degreesPerSec = 360f;

    private Transform player;
    private Vector3 bulletDirection;
    
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // normalizes shooting speed and direction
        bulletDirection = player.position - transform.position;
        bulletDirection.z = 0;
        bulletDirection.Normalize();

        Destroy(gameObject, destroyTime); 
    }

    void Update()
    {
        transform.position += bulletDirection * bulletSpeed *  Time.deltaTime;

        //spins bullet 
        float rotateAmount = degreesPerSec * Time.deltaTime; 
        float curRotate = transform.localRotation.eulerAngles.z; 
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRotate + rotateAmount));
        
    }

   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground") || col.CompareTag("PlayerBullet")) {
            Destroy(gameObject);
            return;
        }
        
        Player player = col.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}