using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public static int maxHp;
    public static int currentHp;
    public Image healthbar;
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
       healthbar.fillAmount=(float)currentHp/(float)maxHp;
        if(currentHp<=0)
        {
            currentHp= 0;
        }
    }
}
