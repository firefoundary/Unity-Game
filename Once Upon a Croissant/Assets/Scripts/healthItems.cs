using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthItems : MonoBehaviour
{
    public GameObject hpFullNotif;


    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) 
        {
            Player player = col.gameObject.GetComponent<Player>();
            if (player.health != player.numOfHearts) 
            {
                player.health += 1;
                player.healthParticles.Play();
                player.hpSound.Play();
                Destroy(gameObject);
            } 
            else 
            {
                Instantiate(hpFullNotif, player.transform.position, hpFullNotif.transform.rotation);
            }
        }
    }
}
