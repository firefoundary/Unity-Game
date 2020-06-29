using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovement : MonoBehaviour
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

    //dust particles
    public ParticleSystem dust;
    public bool spawnDust;

    //sprite characteristics
    public Animator animator;
    public Rigidbody2D rb;
    private bool facingRight = true;

    //audio
    public AudioClip landingSound;
    public AudioClip jumpSound;
    private AudioSource source;

    //dialogueFreeze
    public bool dialogueFreeze;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        extraJumps = extraJumpsValue;
    }

    void FixedUpdate()
    {
        // everything except jump logic and spawn dust

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

        spawnDustOnLand();         
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
        source.clip = jumpSound;
        source.Play();
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
                source.clip = landingSound;
                source.Play();
                spawnDust = false;
            }
        } else {
            spawnDust = true;
        }
    }

    
}