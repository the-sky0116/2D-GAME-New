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
        direction = Input.GetAxisRaw("Horizontal");
        if (isGrounded)
        {
            rb.velocity = new Vector2(MoveSpeed * direction, rb.velocity.y);
        }
        isGrounded = Physics2D.OverlapCircle(Groundcheck.position, GroundRadius, WhatIsGround);
        DirectionCheck();
        AnimationCheck();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (canJump)
            {
                {
                    rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                    amountJumpLeft--;
                }
            }
        }
        if (isGrounded && rb.velocity.y <= 0)
        {
            amountJumpLeft = amountJump;
        }
        if (amountJumpLeft < 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
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
            isFacinghtRight = !isFacinghtRight;
            transform.localScale = new Vector3(6f, 6f, 0f);
        }
        else if(!isFacinghtRight&&direction<0) 
        {
            isFacinghtRight = !isFacinghtRight;
            transform.localScale = new Vector3(-6f, 6f, 0f);
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
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Groundcheck.position, GroundRadius);
    }
}
