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

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;


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

        if (facingRight == false && moveInput > 0)
            Flip();
        else if (facingRight == true && moveInput < 0)
            Flip();
        
        // Jump Character
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    
    
    private void Flip()
    {
        facingRight = !facingRight; // updates facing direction
        
        //this inverts the x axis
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        
        // THIS ONE rotates along y axis (dunno which is better rn)
        // transform.Rotate(0, 180, 0);
    }

}