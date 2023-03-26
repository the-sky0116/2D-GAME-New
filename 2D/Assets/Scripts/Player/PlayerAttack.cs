using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int PlayerDamage;
    public float startTime;
    public float time;
    private PolygonCollider2D collider2d;
    Animator anim;
    Enemy enemy;
    void Start()
    {
        enemy= GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        anim=GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider2d= GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            collider2d.enabled = true;
            anim.SetTrigger("attack");
            StartCoroutine(StartAttack());
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy")&&other.GetType().ToString()=="UnityEngine.BoxCollider2D")
        {
            other.GetComponent<Enemy>().takeDamage(PlayerDamage);
            
        }
    }
    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(startTime);
        StartCoroutine(disableHitbox());
    }
    IEnumerator disableHitbox()
    {
        yield return new WaitForSeconds(time);
        collider2d.enabled= false;
    }
}
