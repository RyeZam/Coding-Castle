using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int damage;
    public float maxHP;
    public float currentHP;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public bool TakeDamage(float dmg)
    {
        currentHP -= dmg;

        if(currentHP <= 0)
            return true;
        else
            return false;
    }
    
    public void isAttacking()
    {
        animator.SetBool("isAttacking", true);
    }

    public void isNotAttacking()
    {
        animator.SetBool("isAttacking", false);
    }

    public void Hit()
    {
        animator.SetTrigger("isHit");
    }

    public void Dead()
    {
        animator.SetBool("isDead", true);
    }

}
