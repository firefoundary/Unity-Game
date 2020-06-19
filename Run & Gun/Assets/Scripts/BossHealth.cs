using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHealth : MonoBehaviour
{ 
    public float health;
    public float damage;

    public Slider healthBar;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

     // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
    }

    public void TakeDamage(float damage)
    {	
        health -= damage;
        if (health <= 0) {
            // Die();
        }
    }
}
