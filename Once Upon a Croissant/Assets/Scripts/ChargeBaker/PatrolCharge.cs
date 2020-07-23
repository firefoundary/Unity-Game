using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCharge : MonoBehaviour
{
    public float speed;
    public float groundDistance;
    public float wallDistance;

    public Transform groundDetection;
    public Transform wallDetection;

    public bool movingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //ground detection
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, groundDistance);
        if (!groundInfo.collider) {
            Debug.Log("no ground");
            if(movingRight) {
                // transform.eulerAngles = new Vector3(0, 180, 0);
                transform.Rotate(0, 180, 0);
                movingRight = false;
                GetComponent<ChargeEnemy>().isFlipped = !GetComponent<ChargeEnemy>().isFlipped;
            } else {
                // transform.eulerAngles = new Vector3(0, 0, 0);
                transform.Rotate(0, 180, 0);
                movingRight = true;
                GetComponent<ChargeEnemy>().isFlipped = !GetComponent<ChargeEnemy>().isFlipped;
            }
        }

        // wall detection
        if (movingRight == true)
        {
            RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, wallDistance);

            if (wallInfo.collider && wallInfo.collider.CompareTag("Ground"))
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = false;
                GetComponent<ChargeEnemy>().isFlipped = !GetComponent<ChargeEnemy>().isFlipped;
            }

        } else 
        {
            RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.left, wallDistance); 

            if (wallInfo.collider && wallInfo.collider.CompareTag("Ground"))
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = true;
                GetComponent<ChargeEnemy>().isFlipped = !GetComponent<ChargeEnemy>().isFlipped;
            }
    
        }

    }
}
