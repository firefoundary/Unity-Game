using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public float attackDamage = 1;
    public Transform attackPos;
    public float attackRange = 1;
    public LayerMask attackMask;


    void Attack()
    {

        Collider2D colInfo = Physics2D.OverlapCircle(attackPos.position, attackRange, attackMask);
        if (colInfo != null)
            colInfo.GetComponent<Player>().TakeDamage(attackDamage);

    }

    public void increaseAttackRange() {
        attackRange = 1.9f;
    }

    
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
