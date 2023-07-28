using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public TrailRenderer tr;
    public Animator Animator;
    public SpriteRenderer sr;

    [Header("Movement")]
    public float MovementSpeed;
    private float Direction;

    [Header("Jumping")]
    public float JumpStrength;
    private bool IsGrounded = true;

    [Header("Dashing")]
    public float MaxDashNumer;
    private bool CanDash = true;
    private bool IsDashing = false;
    private Vector2 DashingDirection;
    private float DashNumber;
    public float DashingVelocity;
    public float DashTime;

    void Update()
    {
        //Gets the direction the player wants to move
        Direction = Input.GetAxisRaw("Horizontal");

        //Triggers a jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpStrength);
            IsGrounded = false;
        }

        //Triggers a dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && CanDash)
        {
            IsDashing = true;
            tr.emitting = true;
            DashingDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            StartCoroutine(StopDashing());

            //Stops you from dashing if your at your max number of dashes (idk why I have to add +1 but it works)
            if (DashNumber + 1 == MaxDashNumer)
            {
                CanDash = false;
            }
        }

        //Moves the player if dashing
        if (IsDashing)
        {
            rb.velocity = DashingDirection.normalized * DashingVelocity;
            rb.gravityScale = 0;
            return;
        }

        //flips the sprite so the player faces the correct way
        if (Direction == 1)
        {
            sr.flipX = false;
        }
        else if (Direction == -1)
        {
            sr.flipX = true;
        }

        //Plays animations
        if (Direction == 0)
        {
            Animator.SetBool("Walking", false);
            Animator.SetBool("Idle", true);
        }
        else
        {
            Animator.SetBool("Walking", true);
            Animator.SetBool("Idle", false);
        }
    }

    //Moves the player left and right if not dashing
    void FixedUpdate()
    {
        if (!IsDashing)
        {
            rb.velocity = new Vector2(Direction * MovementSpeed, rb.velocity.y);
        }
    }

    //If player touches a thing there dashes and jumps get reset
    void OnCollisionStay2D(Collision2D collision)
    {
        IsGrounded = true;
        DashNumber = 0;
        CanDash = true;
    }

    //Ends the players dash
    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(DashTime);
        IsDashing = false;
        DashNumber++;
        rb.gravityScale = 3;
        tr.emitting = false;
    }
}
