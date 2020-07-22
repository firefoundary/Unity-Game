using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    //following Player
    public Transform player;
    public bool isFlipped = false;

    //spawn Eggs
    public GameObject EggSpawner;
    public float eggsDuration;

    //killed particles
    public GameObject killedParticles;

    public GameObject portal;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LookAtPlayer() {

        //flips z axis as well
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped) 
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped) 
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }

    }

    public IEnumerator spawnEggs() {
        EggSpawner.SetActive(true);
        yield return new WaitForSeconds(eggsDuration);
        EggSpawner.SetActive(false);

    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            col.gameObject.GetComponent<Player>().TakeDamage(1);
        }
    }


    //
    //animation event functions
    //

    public void KilledParticles() {
        Instantiate(killedParticles, transform.position, Quaternion.identity);
    }

    public void PlayerTransform() {
        GameObject.Find("Cloak Croissant").GetComponent<Animator>().SetTrigger("Transform");
        gameObject.SetActive(false);
    }

    public void openPortal() {
        portal.SetActive(true);
        portal.GetComponentInChildren<Animator>().SetBool("boss", true);
    }

    public void freezePlayer() {
        //disable palyer movements during ending
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        player.GetComponent<Animator>().SetFloat("Speed", 0);
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerDash>().enabled = false;
        player.GetComponent<WeaponScript>().enabled = false;
        player.GetComponent<GrenadeThrower>().enabled = false;

        Debug.Log("froze player");

    }

    public void unfreezePlayer() {
        //re-enable player movements
        GameObject player = GameObject.Find("Cloak Croissant");

        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerDash>().enabled = true;
        player.GetComponent<WeaponScript>().enabled = true;
        player.GetComponent<GrenadeThrower>().enabled = true;

        Debug.Log("unfroze player");

    }

}
