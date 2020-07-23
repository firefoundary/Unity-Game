using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPillar : MonoBehaviour
{
   
    public bool grenadeBreakable;
    public bool onEnemyDeath;
    public GameObject enemy;

    void Update() {
        if (onEnemyDeath) {
            if (enemy.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("dead"))
                Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "grenade" && grenadeBreakable) {
            col.gameObject.GetComponent<Grenade>().Explode();
            Destroy(gameObject);
        }
    }
}
