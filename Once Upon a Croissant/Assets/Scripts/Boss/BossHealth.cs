using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHealth : MonoBehaviour
{ 
    public float health;
    public Slider healthBar;
    public GameObject healthBarObject;

    public bool isInvulnerable = false;

    public GameObject deathParticles;

    private float halfHealth;
    private bool isAnger = false;

    //lights change
    public GameObject normalLights;
    public GameObject angerLights;
    public GameObject flash;

    //music change
    public GameObject BGM;
    public GameObject newBGM;



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

        // half HP events
        if (!isAnger) {
            if (health <= halfHealth) {

                GetComponent<Animator>().SetBool("isAnger", true);
                StartCoroutine(Transition());
                isAnger = true;

            }
        }
        
        if (health <= 0) {
            Defeated();
        }
    }

    void Defeated() {

        GetComponent<Animator>().SetTrigger("isDefeat");
        // Vector3 position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        // Instantiate(deathParticles, position, Quaternion.identity);

        changeMusic();

        Destroy(healthBarObject);

    }

    IEnumerator Transition() {
        yield return new WaitForSeconds(1f);
        flash.SetActive(true);

        yield return new WaitForSeconds(0.15f);
        normalLights.SetActive(true);
        angerLights.SetActive(true);
        
        yield return new WaitForSeconds(3f);
        flash.SetActive(false);
    }

    void changeMusic() {
        BGM.SetActive(false);
        newBGM.SetActive(true);
    }

    public void particles() {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(deathParticles, position, Quaternion.identity);
    }

    

}
