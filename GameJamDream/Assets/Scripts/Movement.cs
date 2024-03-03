using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro.Examples;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    private BoxCollider2D coll;
    public float jump;
    private bool isTurningRight;
    private Animator anim;


    [SerializeField] private LayerMask jumpGround;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

     void Update()
    {
        Jump();
        // referance to bool
        bool hasGun = anim.GetBool("hasGun");
        bool hasGunRun = anim.GetBool("hasGunRun");

        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        //flip transform
        

        if (move < 0 && !isTurningRight)
        {
            // ... flip the player.
            Flip();
        }
        else if (move > 0 && isTurningRight)
        {
            // ... flip the player.
            Flip();
        }
        if(move > 0f && hasGun == false)
        {
            anim.SetBool("running", true);
        }
        else if (move < 0f && hasGun == false)
        {
            anim.SetBool("running", true);
        }
        
        else
        {
            anim.SetBool("running", false);
        }
        if (move > 0f && hasGun == true)
        {
            anim.SetBool("hasGun", true);
            anim.SetBool("hasGunRun", true);
        }
        else if (move < 0f && hasGun == true)
        {
            anim.SetBool("hasGun", true);
            anim.SetBool("hasGunRun", true);
        }
        else
        {
            anim.SetBool("hasGunRun", false);
        }
    }

    private void Jump()
    {
        if (Input.GetKey("space") && IsGrounded())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
        }
    }

    private bool IsGrounded()
    {
    
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }

    private void Flip()
    {
        isTurningRight = !isTurningRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public void DieThere()
    {
        bool hasGun = anim.GetBool("hasGun");
        if (hasGun == true)
        {
            // Play death with gun clip
            GetComponent<Animator>().Play("PlayerDeath 2");          
        }
        else
        {
            // Play death without gun clip
            GetComponent<Animator>().Play("PlayerDeath");
            
        }       
        GetComponent<Animator>().SetTrigger("death");     
    }
}
