using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int healthHP;
    public Text hpText;
    
    // Start is called before the first frame update
    void Start()
    {
        Healthbar.maxHp = healthHP;
        hpText.text = healthHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DamagePlayer(int damage)
    {
        healthHP-=damage;
        Healthbar.currentHp= healthHP;
        hpText.text = healthHP.ToString();
        if(healthHP <= 0 ) 
        {
            Destroy(gameObject);
            
        }
    }
}
