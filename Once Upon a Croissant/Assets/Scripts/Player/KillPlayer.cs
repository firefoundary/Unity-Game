using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public Transform respawnPoint;
	public Animator transition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {

            GameObject player = col.gameObject;
            transition.SetTrigger("Start");

            player.GetComponent<Player>().TakeDamage(1);
            player.GetComponent<PlayerMovement>().enabled = false;
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0.1f;

            Invoke("respawnPlayer", 1);

        }

        //kill baker too
        if (col.gameObject.CompareTag("Enemy")) {
            col.gameObject.GetComponent<Enemy>().Die();
        }
    }

    void respawnPlayer() {

        GameObject player = GameObject.FindWithTag("Player");
        transition.SetTrigger("End");

        player.transform.position = respawnPoint.position;
        player.GetComponent<PlayerMovement>().enabled = true;
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        rb.gravityScale = 4.5f;
        
    }
}
