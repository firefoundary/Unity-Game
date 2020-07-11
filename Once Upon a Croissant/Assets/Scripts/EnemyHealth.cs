using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 4;
    public float colDamage = 1;

    //death particles and damage effects
    public GameObject effect;
    public GameObject bloodSplash;
    public GameObject hurtEffect;
    public SpriteRenderer[] body;
    public Color hurtColor;

    //audio
    public AudioSource hurtSound;

    public void TakeDamage(float damage)
    {	
        StartCoroutine(Flash());

        hurtSound.Play();

        health -= damage;


        if (health <= 0)
            Die();

        Instantiate(hurtEffect, transform.position, Quaternion.identity);

        
    }

    void Die()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y - 1, -8.8f);

        // death particles
        Instantiate(effect, position, Quaternion.identity);
        Instantiate(bloodSplash, position, Quaternion.identity);
        Destroy(gameObject);
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
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player")) {

            col.gameObject.GetComponent<Player>().TakeDamage(colDamage);

        }
    }
}
