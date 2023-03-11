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
    public float WallSlidingSpeed;
    public float MoveForceAir;
    Rigidbody2D rb;
    public Transform Groundcheck;
    public Transform WallCheck;
    public LayerMask WhatIsGround;
    public float GroundRadius;
    public float wallCheckDistance;
    public int amountJump = 1;
    private int amountJumpLeft;
    bool isWalking;
    bool isGrounded;
    bool isTouchwall;
    bool isFacinghtRight;
    bool canJump;
    bool isWallSliding;
    Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        
    }

    void Update()
    {
        CheckJump();
        CheckSliding();
        Jump();
        Move();
        DirectionCheck();
        CheckSurrounding();
        AnimationCheck();
        
    }
    private void Move()
    {
        direction = Input.GetAxisRaw("Horizontal");
        if(isGrounded)
        {
            rb.velocity = new Vector2(MoveSpeed * direction, rb.velocity.y);
        }
        else if(!isGrounded&&!isWallSliding&&direction!=0)
        {
            Vector2 forcetoAdd = new Vector2(MoveForceAir * direction, 0);
            rb.AddForce(forcetoAdd);

            if(Mathf.Abs(rb.velocity.x)>MoveSpeed)
            {
                rb.velocity=new Vector2 (MoveSpeed*direction, rb.velocity.y);
            }
        }
        if(isWallSliding)
        {
            if(rb.velocity.y<-WallSlidingSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -WallSlidingSpeed);
            }
        }
        
        
    }
    private void AnimationCheck()
    {
        anim.SetBool("Walking",isWalking);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isSliding", isWallSliding);
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
        if (!isWallSliding)
        {
            isFacinghtRight=!isFacinghtRight;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }
       

    private void CheckJump()
    {
        if(isGrounded&&rb.velocity.y<=0) 
        {
            amountJumpLeft =  amountJump;
        }
        if(amountJumpLeft<=0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }
    private void CheckSliding()
    {
        if(isTouchwall&&!isGrounded&&rb.velocity.y<0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }
    private void Jump() 
    {
        if(canJump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                amountJumpLeft--;
            }
            
        }                    
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Groundcheck.position, GroundRadius);
        Gizmos.DrawLine(WallCheck.position, new Vector3(WallCheck.position.x+wallCheckDistance,WallCheck.position.y,WallCheck.position.z));
    }
    private void CheckSurrounding()
    {
        isGrounded = Physics2D.OverlapCircle(Groundcheck.position, GroundRadius, WhatIsGround);
        isTouchwall = Physics2D.Raycast(WallCheck.position, transform.right, wallCheckDistance, WhatIsGround);
    }
}
