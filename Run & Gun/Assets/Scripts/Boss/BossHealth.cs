using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHealth : MonoBehaviour
{ 
    public float health;
    public Slider healthBar;

    public bool isInvulnerable = false;

    public GameObject deathParticles;

    private float halfHealth;

    // Start is called before the first frame update
    void Start()
    {
        halfHealth = health/2;
    }

     // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
    }

    public void TakeDamage(float damage)
    {	
        if (isInvulnerable)
            return;

        health -= damage;

        if (health <= halfHealth)
            GetComponent<Animator>().SetBool("isAnger", true);

        
        if (health <= 0) {
            Die();
        }
    }

    void Die() {

        Vector3 position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

        Instantiate(deathParticles, position, Quaternion.identity);
        Destroy(gameObject);

    }


}
