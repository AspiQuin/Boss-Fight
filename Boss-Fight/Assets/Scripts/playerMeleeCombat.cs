using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMeleeCombat : MonoBehaviour
{
    public Animator animator;

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
        animator.SetTrigger("MeleeAttack");
    }
}
