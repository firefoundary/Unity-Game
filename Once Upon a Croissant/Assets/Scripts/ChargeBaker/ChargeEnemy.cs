using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemy : MonoBehaviour
{
    public bool isFlipped = false;
    private Transform player;

    public float chargeRange = 4;

    public bool canCharge = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chargeRange);
    }
}


