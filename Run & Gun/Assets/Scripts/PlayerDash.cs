using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{   
    //dash stats
    public float dashSpeed;
    public float cooldown;
    public float startDashTime;
    private float dashTime;
    public GameObject dashParticles;

    //private variables
    private int direction = 0;
    private Rigidbody2D rb;
    private float moveInput;
    private bool madeParticles = false;
    private bool canDash = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    void Update() {
        moveInput = GetComponent<PlayerMovement>().moveInput;
    }

    public void Dash() {
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
                madeParticles = false;

            }
            else {
                if(direction == 1 && canDash) {
                    if(!madeParticles) {
                        GameObject.Instantiate(dashParticles, transform.position, dashParticles.transform.rotation * Quaternion.Euler(0f, 180f, 0f));
                        madeParticles = true;
                    }
                    rb.velocity = Vector2.left * dashSpeed;
                    StartCoroutine(coolDown());
                }
                else if (direction == 2 && canDash) {
                    if(!madeParticles) {
                        Instantiate(dashParticles, transform.position, dashParticles.transform.rotation);
                        madeParticles = true;
                    }
                    rb.velocity = Vector2.right * dashSpeed;
                    StartCoroutine(coolDown());
                }

                dashTime -= Time.deltaTime;
            }
        }      
    }

    IEnumerator coolDown() {
        yield return new WaitForSeconds(dashTime);
        canDash = false;
        yield return new WaitForSeconds(cooldown);
        canDash = true;
    }
}
