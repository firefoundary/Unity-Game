using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //speed and inputs
    public float runSpeed;
    public float jumpForce;
	public float hookAirSpeed = 10;
    private float moveInput;

    //groundchecks
    public bool isGrounded = false;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //jumps
    private int extraJumps;
    public int extraJumpsValue;
    
    //dust particles
    public ParticleSystem dust;

    //sprite characteristics
    public Animator animator;
    private Rigidbody2D rb;
    private bool facingRight = true;

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
			
		if (!GameObject.FindWithTag("Grapple").GetComponent<Grapple>().isGrappling) 
		{
			if (GameObject.FindWithTag("Grapple").GetComponent<Grapple>().releasing)
			{
				if((rb.velocity.x >= 0 && moveInput == 1) || rb.velocity.x <= 0 && moveInput == -1)	
					rb.AddForce(new Vector2(moveInput * runSpeed, 0));

				if((rb.velocity.x > 0 && moveInput == -1) || rb.velocity.x < 0 && moveInput == 1)	
					rb.AddForce(new Vector2(hookAirSpeed * moveInput * runSpeed, 0));

			}else 
			{
        		rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
			}
		}	

        //plays run animation
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (facingRight == false && moveInput > 0)
            flip();
        else if (facingRight == true && moveInput < 0)
            flip();
    }

    void Update()
    {
        // first jump
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            if(isGrounded == true) createDust();
            // rb.velocity = Vector2.up * jumpForce;
            rb.velocity = new Vector2(rb.velocity.x, 1 * jumpForce); // maintains horz velocity on jump
            animator.SetBool("isJumping", true);
            animator.SetBool("isLanding", false);
            extraJumps--;
        } else if (Input.GetButtonDown("Jump") && extraJumps == 0)  // second jump
        {
            // rb.velocity = Vector2.up * jumpForce;
            rb.velocity = new Vector2(rb.velocity.x, 1 * jumpForce); // maintains horz velocity on jump
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
        
        //inverts x axis
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
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