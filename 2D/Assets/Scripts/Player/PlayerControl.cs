using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float MoveSpeed;
    public float direction;
    public float JumpForce;
    Rigidbody2D rb;
    public Transform Groundcheck;
    public LayerMask WhatIsGround;
    public float GroundRadius;
    bool isWalking;
    bool isGrounded;
    bool isFacinghtRight;
    Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
        DirectionCheck();
        CheckSurrounding();
    }

    void Update()
    {
        Jump();
        
    }
    private void Move()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(MoveSpeed * direction, rb.velocity.y);
        anim.SetBool("Walking",isWalking);
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
    private void Jump() 
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            }          
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
