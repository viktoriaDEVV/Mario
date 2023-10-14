using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D rb;
    public float horizontal;
    private bool flip = true;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
        animator.SetFloat("moveX",Mathf.Abs (horizontal));

        /*if(horizontal>0 && !flip)
        {
            Flip();
        }else if(horizontal<0 && flip)
        {
            Flip();
        }*/
        if((horizontal > 0 && !flip) || (horizontal < 0 && flip))
        {
            transform.localScale *= new Vector2(-1,1);
            flip = !flip;
        }
    }
    /*void Flip()
    {
        flipRight = !flipRight;
        Vector3 theScale = transform.localScale;
        theScale.x = theScale.x * (-1);
        transform.localScale = theScale;
    } */
}
