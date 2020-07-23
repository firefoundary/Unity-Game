using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;

    //death particles and damage effects
    public GameObject effect;
    public GameObject hurtEffect;
    public SpriteRenderer[] body;
    public Color hurtColor;

    public AudioSource deathSound;

    //audio
    public AudioSource hurtSound;

    public void TakeDamage(float damage)
    {	
        StartCoroutine(Flash());

        health -= damage;

        if (health <= 0) {
            Die();
            return;
        }

        hurtSound.Play();
        Instantiate(hurtEffect, transform.position, Quaternion.identity);

        
    }

    public void Die()
    {
        //decrement death counter
        GameObject enemies = GameObject.Find("Enemies");
        enemies.GetComponent<OpenPortal>().deathCounter -= 1;

        //death sound
        deathSound.Play();

        // death particles
        Vector3 position = new Vector3(transform.position.x, transform.position.y, -8.8f);
        Instantiate(effect, position, Quaternion.identity);

        GetComponent<PatrolCharge>().enabled = false;
        GetComponent<Animator>().SetTrigger("dead");
        this.enabled = false;
    }
    
    IEnumerator Flash() {
        foreach (SpriteRenderer b in body) {
            b.color = hurtColor;
        }

        yield return new WaitForSeconds(0.075f);

        foreach (SpriteRenderer b in body) {
            b.color = Color.white;
        }

    }

    // player collision damage
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            col.gameObject.GetComponent<Player>().TakeDamage(1);
        }
    }
}
