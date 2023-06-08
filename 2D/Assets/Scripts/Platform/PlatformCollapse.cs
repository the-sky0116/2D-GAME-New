using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlatformCollapse : MonoBehaviour
{
    Animator anim;

    Collider2D box2D;
    void Start()
    {
        box2D= GetComponent<Collider2D>();
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            anim.SetTrigger("Collapse");
        }
    }
    void DisableBoxCollider2D()
    {
        box2D.enabled = false;
    }
    void DestroyTrapPlatform()
    {
        Destroy(gameObject);
    }
}
