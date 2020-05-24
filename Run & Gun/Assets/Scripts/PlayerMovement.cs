using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed;
    public float jumpForce;
    private float moveInput;
    
    private Rigidbody2D rb;
    private bool facingRight = false;

    private bool isGrounded = false;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;
    
    public Animator animator;
    
    //dust particles
    public ParticleSystem dust;



    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        // Move Character
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        //plays run animation
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (facingRight == false && moveInput > 0)
            Flip();
        else if (facingRight == true && moveInput < 0)
            Flip();
        
        
    }

    void Update()
    {
        //jumps character
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            animator.SetBool("isJumping", false);
        }
        
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            if(isGrounded == true) createDust();
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
            extraJumps--;
        } else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
        }
        
    }
    
    
    private void Flip()
    {
        facingRight = !facingRight; // updates facing direction
        
        if(isGrounded == true) createDust();
        
        //this inverts the x axis
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        
        
        
        // THIS ONE rotates along y axis (dunno which is better rn)
        // transform.Rotate(0, 180, 0);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
            isGrounded = true;
    }
    
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
            isGrounded = false;
    }
    
    void createDust()
    {
        dust.Play();
    }


}