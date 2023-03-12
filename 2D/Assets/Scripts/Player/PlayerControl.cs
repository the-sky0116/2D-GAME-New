using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class PlayerControl : MonoBehaviour
{
    public float MoveSpeed;
    public float direction;
    public float JumpForce;


    Rigidbody2D rb;
    public Transform Groundcheck;
    public LayerMask WhatIsGround;
    public float GroundRadius;
    public int amountJump = 1;
    public int amountJumpLeft;
    bool isWalking;
    bool isGrounded;
    bool isFacinghtRight;
    bool canJump;
    Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        DirectionCheck();
        Move();
        CheckSurrounding();
        AnimationCheck();
    }

    void Update()
    {
        ApplyJump();
        CheckIfCanJump();

    }
    private void Move()
    {
        direction = Input.GetAxisRaw("Horizontal");
        if(isGrounded)
        {
            rb.velocity = new Vector2(MoveSpeed * direction, rb.velocity.y);
        }
        
        
    }
    private void AnimationCheck()
    {
        anim.SetBool("Walking",isWalking);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
    }
    
    private void DirectionCheck()
    {
        if(isFacinghtRight&&direction>0)
        {
            Flip();
        }
        else if(!isFacinghtRight&&direction<0) 
        {
            Flip();
        }
        if(rb.velocity.x!=0) 
        {
            isWalking= true;
        }
        else
        {
            isWalking= false;
        }
    }
    private void Flip()
    {
        isFacinghtRight=!isFacinghtRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
     private void ApplyJump()
     {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
     }
    private void Jump()
    {
        if(canJump)
        {
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                amountJumpLeft--; 
            }
        }
    }
    private void CheckIfCanJump()
    {
        if(isGrounded&&rb.velocity.y<=0)
        {
            amountJumpLeft = amountJump;
        }
        if(amountJumpLeft<0)
        {
            canJump = false;
        }
        else
        {
            canJump= true;
        }
    }




    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Groundcheck.position, GroundRadius);
    }
    private void CheckSurrounding()
    {
        isGrounded = Physics2D.OverlapCircle(Groundcheck.position, GroundRadius, WhatIsGround);
    }
}
