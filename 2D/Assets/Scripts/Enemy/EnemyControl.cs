using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : Enemy
{
    public float speed;
    public float waitTime;
    public Transform[] movePos;

    private int i = 0;
    private bool isFacingRight = true;
    private float wait;
    void Start()
    {
        wait = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed*Time.deltaTime);
    }

}
