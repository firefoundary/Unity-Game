using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed;
    public float startDashTime;
    private float dashTime;

    private int direction = 0;
    public GameObject dashParticles;

    private Rigidbody2D rb;
    private float moveInput;

    private bool madeParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = GetComponent<PlayerMovement>().moveInput;

        //dash logic
        if (direction == 0) 
        {
            if(Input.GetKeyDown(KeyCode.LeftShift)) 
            {
                if(moveInput < 0)
                    direction = 1;
                else if (moveInput > 0)
                    direction = 2;
            }  
        } 
        else 
        {
            if (dashTime <= 0) 
            {
                direction = 0;
                dashTime = startDashTime;

                rb.velocity = Vector2.zero;
                madeParticles = false;

            }
            else {
                dashTime -= Time.deltaTime;

                if(direction == 1) {
                    if(!madeParticles) {
                        Instantiate(dashParticles, transform.position, dashParticles.transform.rotation);
                        madeParticles = true;
                    }
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2) {
                    if(!madeParticles) {
                        Instantiate(dashParticles, transform.position, dashParticles.transform.rotation);
                        madeParticles = true;
                    }
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
        }
    }
}
