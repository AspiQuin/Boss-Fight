using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMeleeCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Calls the animiation for the sword attack
        animator.SetTrigger("MeleeAttack");
        //Detects if boss is in range of the attack
        Collider2D[] bossHurtbox = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        //Damages boss
        foreach(Collider2D bossHit in bossHurtbox)
        {
            Debug.Log("Boss was hit");
            GameObject.Find("boss").GetComponent<DamageScript>().Health -= 30;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
