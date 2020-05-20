using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    private bool isJumping;
    
    private Rigidbody2D rb;
    private float move;
    private bool facingRight = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // Move Character
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * runSpeed, rb.velocity.y);
        
        // Flip Character
        if (move < 0 && facingRight)
            flip();
        else if (move > 0 && !facingRight)
            flip();
    
        // Jump Character
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
            isJumping = true;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Indicate no longer jumping
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    
    private void flip()
    {
        facingRight = !facingRight; // updates facing direction
        transform.Rotate(0, 180, 0);
    }
    
    
    
    
}