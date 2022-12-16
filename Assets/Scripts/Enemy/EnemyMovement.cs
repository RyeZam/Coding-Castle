using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;


    public bool shouldRotate;

    public LayerMask whatisPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator animate;
    private Vector2 movement;
    public Vector3 dir;
    SpriteRenderer spriteRenderer;

    private bool isinChaseRange;
    private bool isinAttackRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animate.SetBool("IsEnter", isinChaseRange);

        isinChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatisPlayer);
        isinAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatisPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //dir.Normalize();
        movement = dir;
        if (shouldRotate)
        {
            animate.SetFloat("x", dir.x);
            animate.SetFloat("y", dir.y);

            if (dir.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (dir.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if(isinChaseRange && !isinAttackRange)
        {
            MoveCharacter(movement);
        }
        if (isinAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
}
