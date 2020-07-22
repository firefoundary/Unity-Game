using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargeBlocker : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D col) {
        // layer 17 is chargebaker
        if (col.gameObject.layer == 17)
            col.gameObject.GetComponent<Animator>().SetTrigger("Walk");
    }
}
