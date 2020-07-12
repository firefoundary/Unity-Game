using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargeBoundary : MonoBehaviour
{
    public GameObject chargeBaker;

    private ChargeEnemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = chargeBaker.GetComponent<ChargeEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            enemy.canCharge = true;
        }
    }

    void OnTriggerExit2D (Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            enemy.canCharge = false;
        }
    }
}
