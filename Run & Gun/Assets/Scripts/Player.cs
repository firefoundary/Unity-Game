using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public SpriteRenderer body;
    public Color hurtColor;

    public bool hurt = false;
    public GameObject hurtEffect;

    //audio
    public AudioClip hurtSound;
    private AudioSource source;

    //health
    public float health = 10;
    public int numOfHearts; 
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;



    void Start() {
        source = GetComponent<AudioSource>();
    }

    void Update() {

        HealthBar();

    }

    public void TakeDamage(float damage)
    {	
        hurt = true;
        Instantiate(hurtEffect, transform.position, Quaternion.identity);

        source.clip = hurtSound;
        source.Play();        

        StartCoroutine(Flash());
        health -= damage;

        if (health <= 0)
            Die();
    }

 void Die()
    {

        //can add death particles here
        Destroy(gameObject);
    }

    IEnumerator Flash() {

        body.color = hurtColor;
        yield return new WaitForSeconds(0.075f);
        body.color = Color.white;
        hurt = false;

    }

    void HealthBar() {
        
        if (health > numOfHearts)
            health = numOfHearts;

        //health bar update
        for (int i = 0; i < hearts.Length; i++) {

            if (i < health)
                hearts[i].sprite = fullHeart;
            else 
                hearts[i].sprite = emptyHeart;

            
            if (i < numOfHearts)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
                
        }
    }
}
