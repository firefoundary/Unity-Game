using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyRespawns : MonoBehaviour
{
    public GameObject respawnPoint;
    
    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            Destroy(respawnPoint);
        }
    }

}
