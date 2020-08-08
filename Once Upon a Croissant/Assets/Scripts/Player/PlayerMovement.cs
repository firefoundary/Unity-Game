using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //speed and inputs
    public float runSpeed;
    public float jumpForce;
    public float moveInput;

    //groundchecks
    public bool isGrounded = false;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //jumps
    private int extraJumps;
    public int extraJumpsValue;

    //wall slide
    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;

    //wall jump
    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;

    //dust particles
    public ParticleSystem dust;
    public bool spawnDust;

    //sprite characteristics
    public Animator animator;
    public Rigidbody2D rb;
    public bool facingRight = true;
    
    // private AudioSource source;
    public AudioSource jumpSound;

    //dialogueFreeze
    public bool dialogueFreeze;

    //reference to playerdash script
    private PlayerDash playerDash;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerDash = GetComponent<PlayerDash>();
        extraJumps = extraJumpsValue;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
        moveInput = Input.GetAxisRaw("Horizontal");
		
        //movement logic
        if (!dialogueFreeze)
            rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        else rb.velocity = new Vector2(0, rb.velocity.y);


        //plays run animation
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        //flip logic
        if (!facingRight && moveInput > 0) {
            flip();
        }
        else if (facingRight && moveInput < 0){
            flip();
        }

        //dash logic
        if (!dialogueFreeze)
            playerDash.Dash();

        //jump logic
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            if(isGrounded == true) 
                dust.Play();

            Jump();
            animator.SetBool("isJumping", true);
            animator.SetBool("isLanding", false);
        } else if (Input.GetButtonDown("Jump") && extraJumps == 0)  // second jump
        {
            Jump();
            animator.SetBool("isJumping", false);
            animator.SetBool("isJumping2", true);
            animator.SetBool("isLanding", false);
        }

        //wall slide logic
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

        if (isTouchingFront && !isGrounded && moveInput != 0)
            wallSliding = true;
        else 
            wallSliding = false;

        if (wallSliding)
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        
        //wall jump logic
        if (Input.GetButtonDown("Jump") && wallSliding) {
            wallJumping = true;
            Invoke("WallJumpFalse", wallJumpTime);
        }

        if (wallJumping)
            rb.velocity = new Vector2(xWallForce * -moveInput, yWallForce);

        spawnDustOnLand();         
    }

    void WallJumpFalse() {
        wallJumping = false;
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


    //
    //HELPER FUNCTIONS
    //


    void Jump() {
        jumpSound.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // maintains horz velocity on jump
        extraJumps--;

    }
    
    private void flip()
    {
        facingRight = !facingRight; // updates facing direction

        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        transform.localScale = flipped;

        // transform.eulerAngles = new Vector3(0, y, 0);
        transform.Rotate(0, 180, 0);

        if(isGrounded) 
            dust.Play();
    }

    void spawnDustOnLand() {
        if(isGrounded == true) {
            if (spawnDust == true) {
                dust.Play();
                spawnDust = false;
            }
        } else {
            spawnDust = true;
        }
    }

    
}