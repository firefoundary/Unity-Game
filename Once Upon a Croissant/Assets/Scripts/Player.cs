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
    public CameraShake2 cameraShake;

    //health
    public float health = 10;
    public int numOfHearts; 
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    //enemy collision
    public float timeBtwDamage = 1;
    private bool isInvulnernable = false;

    //audio
    public AudioSource damageSound;

    //hp item particles
    public ParticleSystem healthParticles;
    public AudioSource hpSound;

    //animation particles
    public GameObject transformParticles;

    //test
    public new CameraShakeBrackeys camera;

    void Start() {
        healthParticles.Stop();
    }

    void Update() {

        HealthBar();
    }

    public void TakeDamage(float damage)
    {	
        if (isInvulnernable)
            return;

        GetComponent<TimeStop>().StopTime();

        // StartCoroutine(cameraShake.Shake());
        StartCoroutine(camera.Shake());

        health -= damage;
        if (health <= 0) {
            HealthBar();
            Die();
            return;
        }
            

        hurt = true;
        // Instantiate(hurtEffect, transform.position, Quaternion.identity);

        
        damageSound.Play();        

        StartCoroutine(Flash());
        

    }

 void Die()
    {
        //can add death particles here
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().EndGame();
    }

    IEnumerator Flash() {

        isInvulnernable = true;

        yield return new WaitForSeconds(0.1f);

        body.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.1f);
        body.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.1f);
        body.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.1f);
        body.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.1f);
        body.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.1f);
        body.color = new Color(1, 1, 1, 1);
        

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

    //
    // animation events
    //

    public void transformPlayer() {
        Instantiate(transformParticles, transform.position, Quaternion.identity);
       
        GetComponent<SwitchCharacterScript>().changeSprite();
        GetComponent<SwitchCharacterScript>().changeCameraFocus();

	
    }



}













