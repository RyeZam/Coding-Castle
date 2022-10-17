using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Collider2D swordCollider;
    Vector2 rightAttackOffset;
    public float damage = 2f;
        
    private void Start()
    {
        rightAttackOffset = transform.localPosition;
        if (swordCollider == null)
        {
            Debug.LogWarning("Sword Collider not Set!");
        }

    }

    public void AttackRight()
    {
        //Debug.Log("Right");
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }
    public void AttackLeft()
    {
        //Debug.Log("Left");
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }
    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    /*void OnCollisionEnter2D(Collision2D col)
    {
        col.collider.SendMessage("OnHit", damage);
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        //other.SendMessage("OnHit", damage);

        if(other.CompareTag("Enemy"))
        {
            //deal damage
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.Health -= damage;
            }
        }
        else if (other.CompareTag("breakable"))
        {
            other.GetComponent<Barrel>().Smash();
        }
    }
}
