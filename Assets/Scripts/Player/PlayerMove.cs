using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class PlayerMove : MonoBehaviour
{
    /*bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }*/

    public float moveSpeed = 1.5f;
    //public float maxSpeed = 0.75f;
    //public float idleFriction = 0.9f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public Weapon swordAttack;
    public Vector2 export;
    public GameObject item, textBox;

    Vector2 movementInput = Vector2.zero;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    public AudioSource footsteps;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;
    //bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        FindObjectOfType<AudioManager>().Play("Quiz");
    }

    private void FixedUpdate()
    {
        State.lvlState = "Quiz";
        if (canMove)
        {
            // If movement input is not 0, try to move
            if (movementInput != Vector2.zero)
            {
                //rb.velocity = Vector2.ClampMagnitude(rb.velocity + (movementInput * moveSpeed * Time.deltaTime), maxSpeed);

                bool success = TryMove(movementInput);

                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));
                }

                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }

                animator.SetBool("isMoving", success);
                export = movementInput;      
                //export = GetComponent<GrabObject>().lookdir;
            }
            else
            {
                animator.SetBool("isMoving", false);
                footsteps.enabled = false;
                //FindObjectOfType<AudioManager>().Stop("Walk");
            }

            // Set direction of sprite to movement direction
                if (movementInput.x < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else if (movementInput.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
                //IsMoving = true;
        }

        if (Chest.opened)
            {
                StartCoroutine(openAnimation());
            }
        /*else
        {
            //rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            //IsMoving = false;
        }*/  
    }

    IEnumerator openAnimation()
    {
        LockMovement();
        textBox.SetActive(true); 
        animator.SetBool("received", true);
        item.SetActive(true);

        yield return new WaitForSeconds(2.5f);

        animator.SetBool("received", false);
        item.SetActive(false);
        textBox.SetActive(false);
        Chest.opened = false;
        UnlockMovement();
    }

    /*void UpdateAnimatorParameters()
    {
        animator.SetBool("isMoving", isMoving);
    }*/

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            // Check for potential collisions
            int count = rb.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
                movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset

            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                footsteps.enabled = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            // Can't move if there's no direction to move in
            return false;
        }

    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
        SwordAttack();
    }

    public void SwordAttack()
    {
        //LockMovement();

        FindObjectOfType<AudioManager>().Play("Sword");

        if (spriteRenderer.flipX == true)
            swordAttack.AttackLeft();
        else
            swordAttack.AttackRight();
    }

    public void EndSwordAttack()
    {
        //UnlockMovement();
        swordAttack.StopAttack();
    }

    public void LockMovement()
    {
        animator.SetBool("isMoving", false);
        footsteps.enabled = false;
        canMove = false;
    }

    public void UnlockMovement()
    {
        animator.SetBool("isMoving", true);
        canMove = true;
    }
}
