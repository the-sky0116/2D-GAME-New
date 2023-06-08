using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockMange : MonoBehaviour
{
    public GameObject GameObjectrock;
    public int maxPos;
    public int minPos;
    public int instPosY;
    public float spwan = 1;

    public float delta = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.spwan)
        {
            this.delta= 0;
            GameObject inst = Instantiate(GameObjectrock) as GameObject;

            int pos = Random.Range(minPos, maxPos);

            inst.transform.position = new Vector3(pos, instPosY, 0);
        }
    }
}
