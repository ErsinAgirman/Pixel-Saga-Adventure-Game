using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{

    private float bounce = 20f;
    public Animator anim;

    void Start() 
    {
        anim = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D other) 
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            anim.SetBool("isJumping",true);
        }
        
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        anim.SetBool("isJumping",false);
    }
}
