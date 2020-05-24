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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        // Move Character
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        //plays run animation
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if ((Input.mousePosition.x < Screen.width/2) && facingRight)
            flip();
        else if ((Input.mousePosition.x > Screen.width/2) && !facingRight)
            flip();
        
        
    }

    void Update()
    {
        // first jump
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            if(isGrounded == true) createDust();
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
            animator.SetBool("isLanding", false);
            extraJumps--;
        } else if (Input.GetButtonDown("Jump") && extraJumps == 0)  // second jump
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", false);
            animator.SetBool("isJumping2", true);
            animator.SetBool("isLanding", false);
            extraJumps--;
        }
        
    }
    
    
    private void flip()
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
    
    void createDust()
    {
        dust.Play();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            extraJumps = extraJumpsValue;
            animator.SetBool("isLanding", true);
            animator.SetBool("isJumping", false);
            animator.SetBool("isJumping2", false);
        }
    }

}