using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillLayer : MonoBehaviour
{
    private GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == ("Player")) {
            col.gameObject.GetComponent<Player>().dieHelper();
            Debug.Log("entered trigger");
        }
    }
}
