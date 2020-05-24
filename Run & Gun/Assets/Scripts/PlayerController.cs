using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    private bool isJumping;
    private Vector2 mouseDirection;
    private Rigidbody2D rb;
    private float move;
    private bool facingRight = true;
    public Animator animator;
    public GameObject gameOverText, restartButton;
    
    //jumping mechanics
    public float jumpForce;
    private int extraJumps;
    public int extraJumpsValue;

    //Checks if player is on ground
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //dust particles
    public ParticleSystem dust;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        restartButton.SetActive(false);
        gameOverText.SetActive(false);
        extraJumps = extraJumpsValue;
    }

    // Update is called once per frame
    void Update()
    {
        // Move Character
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * runSpeed, rb.velocity.y);

        // Movement sets animation state to run
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        
        // Flip Character
        if ((Input.mousePosition.x < Screen.width/2) && facingRight)
            flip();
        else if ((Input.mousePosition.x > Screen.width/2) && !facingRight)
            flip();

        
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        
    
        // Jump Character
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            if(isGrounded == true) createDust();
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--; //prevention of infinite jump
        }
        else if(Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        // game over player touches enemy
        if (col.gameObject.tag.Equals("Enemy"))
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }   
    
    
    private void flip()
    {
        if(isGrounded == true) createDust();
        facingRight = !facingRight; // updates facing direction
        transform.Rotate(0, 180, 0);
    }

    void createDust()
    {
        dust.Play();
    }

}