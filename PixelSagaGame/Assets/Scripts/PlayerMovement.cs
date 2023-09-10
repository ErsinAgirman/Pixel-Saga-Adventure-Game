using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float dirX= 0f;
    [SerializeField] private float moveSpeed= 10f;
    [SerializeField] private float jumpForce = 14f;
    private bool canJump = true;

    private enum MovementState{ idle,running,jumping,falling }

    [SerializeField] private AudioSource jumpSoundEffect;
    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

    }

    
    private void Update()
    {
        //dirX = Input.GetAxisRaw("Horizontal");  //pc keybord kontrolü ile
        rb.velocity = new UnityEngine.Vector2(dirX * moveSpeed,rb.velocity.y);
        UpdateAnimationState();
    }

    public void MoveRight()
    {
        dirX = 1f;
    }

    public void MoveLeft()
    {
        dirX = -1;
    }

    public void StopMoving()
    {
        dirX = 0;
    }

    public void JumpMovement()
    {
        if (isGrounded() && canJump)
        {
             rb.velocity = new UnityEngine.Vector2(rb.velocity.x, jumpForce);
             jumpSoundEffect.Play();
            canJump = false; // Zıpladıktan sonra canJump'ı false olarak ayarlayın.
         }
    }


    private void UpdateAnimationState()
    {
        MovementState state;
        // if (Input.GetButtonDown("Jump") && isGrounded())  //pc controller
        if (!isGrounded())
        {
            canJump = true;
            //jumpSoundEffect.Play();
            //GetComponent<Rigidbody2D>().velocity = new UnityEngine.Vector2(rb.velocity.x, jumpForce);
        }

        if (dirX> 0f)
        {
            state = MovementState.running;

            sprite.flipX = false;
        }
        else if (dirX< 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }

        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state",(int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, UnityEngine.Vector2.down, .1f,jumpableGround);
    }


}
