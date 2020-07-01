using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthItems : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col) {
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
        }
    }
}
