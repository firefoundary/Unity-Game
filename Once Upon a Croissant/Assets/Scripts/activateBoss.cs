using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateBoss : MonoBehaviour
{
    public GameObject boss;

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Player") {
            boss.SetActive(true);
        }
    }
}
