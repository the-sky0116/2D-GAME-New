using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int healthHP;
    
    // Start is called before the first frame update
    void Start()
    {
        Healthbar.maxHp = healthHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DamagePlayer(int damage)
    {
        healthHP-=damage;
        Healthbar.currentHp= healthHP;
        if(healthHP <= 0 ) 
        {
            Destroy(gameObject);
            
        }
    }
}
