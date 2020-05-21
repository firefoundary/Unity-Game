using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
   
}