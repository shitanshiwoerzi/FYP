using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    Animator anim;
    BoxCollider2D bx2d;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bx2d = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Collapse");
        }
    }

    void DisableBoxCollider2D()
    {
        bx2d.enabled = false;
    }

    void DestroyTrapPlatform()
    {
        Destroy(gameObject);
    }
}
