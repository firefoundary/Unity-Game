using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public SpriteRenderer body;
    public Color hurtColor;
    public bool hurt = false;

    public GameObject hitEffect, hitEffect2, deathParticles;

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
    public CameraShakeBrackeys camera;

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



        health -= damage;
        if (health <= 0) {
            HealthBar();
            StartCoroutine(Die());
            return;
        }

        GetComponent<TimeStop>().StopTime();

        StartCoroutine(camera.Shake(0.2f, 0.06f));
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        Vector3 pos = new Vector3 (transform.position.x, transform.position.y, hitEffect2.transform.position.z);
        Instantiate(hitEffect2, pos, Quaternion.identity);

        hurt = true; 
        damageSound.Play();        
        StartCoroutine(Flash());
        

    }

    IEnumerator Die() 
    {
        
        StartCoroutine(camera.Shake(1f, 0.17f));
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<WeaponScript>().enabled = false;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;

        Instantiate(deathParticles, transform.position, Quaternion.identity);
        //death animation here
        yield return new WaitForSeconds(1f);

        Time.timeScale = 1f;
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().EndGame();
        
    }

    public void dieHelper() {
        StartCoroutine(Die());
    }


    IEnumerator Flash() {

        isInvulnernable = true;

        yield return new WaitForSeconds(0.1f);

        body.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.1f);
        body.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        body.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.1f);
        body.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.2f);
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













