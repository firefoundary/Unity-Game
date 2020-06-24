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

    //enemy collision
    public float timeBtwDamage = 1;
    private bool isInvulnernable = false;

    void Start() {
        source = GetComponent<AudioSource>();
    }

    void Update() {

        HealthBar();
    }

    public void TakeDamage(float damage)
    {	
        if (isInvulnernable)
            return;

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

        isInvulnernable = true;

        //body.color = hurtColor;
        body.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.1f);
        body.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.1f);
        body.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.1f);
        body.color = new Color(1, 1, 1, 1);

        //body.color = Color.white;
        hurt = false;

        yield return new WaitForSeconds(timeBtwDamage);
        isInvulnernable = false;

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













