using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    public int Damage;

    PlayerHealth playerhealth;
    void Start()
    {
        playerhealth= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Health<=0)
        {
           // Destroy(gameObject);
        }
    }
    public void takeDamage(int damage)
    {
        Health-= damage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.BoxCollider2D")
        {
            playerhealth.DamagePlayer(Damage);
            Debug.Log("Hit");
        }
    }
}
