using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float MoveSpeed;
    public float direction;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        
    }
    private void Move()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(MoveSpeed * direction, rb.velocity.y);
    }
}
