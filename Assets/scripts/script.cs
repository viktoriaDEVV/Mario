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
    public int jumpForce = 2;
    public bool onGroud;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float GroundCheckRadius;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GroundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
        animator.SetFloat("moveX",Mathf.Abs (horizontal));
        animator.SetFloat("jump 0", Mathf.Abs(jumpForce));
        /*if(horizontal>0 && !flip)
        {
            Flip();
        }else if(horizontal<0 && flip)
        {
            Flip();
        }*/
        if ((horizontal > 0 && !flip) || (horizontal < 0 && flip))
        {
            transform.localScale *= new Vector2(-1,1);
            flip = !flip;
        }
        Jump();
        CheckinngGround();
    }
    /*void Flip()
    {
        flipRight = !flipRight;
        Vector3 theScale = transform.localScale;
        theScale.x = theScale.x * (-1);
        transform.localScale = theScale;
    } */

    void Jump()
    {
        if (onGroud && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void CheckinngGround()
    {
        onGroud = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground); 
    }
}
