using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    public Transform respawnAt;
    
    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            col.transform.position = respawnAt.position;
        }
    }
}
