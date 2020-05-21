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
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        restartButton.SetActive(false);
        gameOverText.SetActive(false);
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
        if (move < 0 && facingRight)
            flip();
        else if (move > 0 && !facingRight)
            flip();
    
        // Jump Character
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Indicate no longer jumping if hit ground
        if (col.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false); 
        }
        
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
        facingRight = !facingRight; // updates facing direction
        transform.Rotate(0, 180, 0);
    }

}