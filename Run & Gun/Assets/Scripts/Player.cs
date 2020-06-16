using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;

    public SpriteRenderer body;
    public Color hurtColor;


    public void TakeDamage(int damage)
    {	
        StartCoroutine(Flash());
        health -= damage;

        if (health <= 0)
            Die();
    }

 void Die()
    {
        // Vector3 position = new Vector3(transform.position.x, transform.position.y - 1, -8.8f);
        
        // death particles
        // Instantiate(effect, position, Quaternion.identity);
        // Instantiate(bloodSplash, position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator Flash() {
        body.color = hurtColor;
        yield return new WaitForSeconds(0.075f);
        body.color = Color.white;
    }
}
