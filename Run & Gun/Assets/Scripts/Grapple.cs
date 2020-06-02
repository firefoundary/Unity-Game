using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer line;
    public Material mat;
    public Rigidbody2D origin;
    public float line_width = 0.1f;
    public float speed = 30;
    public float pull_force = 50;
    public float grappleDistance = 8;
    private Vector2 grappleDir;

    private Vector3 velocity;

    public bool grappling = false;
    public bool released = false;
	private bool existHook = false;
    private bool keepShooting = false;
    
    void Start()
    {
        line = GetComponent<LineRenderer>();
        if (!line)
        {
            line = gameObject.AddComponent<LineRenderer>();
        }

        line.startWidth = line_width;
        line.endWidth = line_width;
        line.material = mat;
    }
    

    // Update is called once per frame
    void Update()
    {
        grappleDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position += velocity * Time.deltaTime;

        if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().isGrounded)
            released = false;

        if (Input.GetKeyDown(KeyCode.Mouse1) && !existHook) 
		{
            setStart(grappleDir);
			existHook = true;
		}

        if (!keepShooting)
            return; 
        
        if (grappling)
        {
            Vector2 dir = (Vector2) transform.position - origin.position;
            origin.AddForce(dir * pull_force);

            if (Input.GetKeyDown(KeyCode.Mouse1) && existHook)
            {
                breakGrapple();
				existHook = false;
                grappling = false;
                released = true;
                return;
            }
        }
        else
        {
            transform.position += velocity * Time.deltaTime;
            float distance = Vector2.Distance(transform.position, origin.position);
            if (distance > grappleDistance)
            {
                breakGrapple();
				existHook = false;
                return;
            }
        }
        
        line.SetPosition(0, transform.position);
        line.SetPosition(1, origin.position);
    }

    void setStart(Vector2 grappleDir)
    {
        Vector2 dir = grappleDir - origin.position;
        dir = dir.normalized;
        velocity = dir * speed;
        transform.position = origin.position + dir;
        grappling = false;
        keepShooting = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        velocity = Vector2.zero;
        grappling = true;
    }

    void breakGrapple()
    {
        keepShooting = false;
        velocity = Vector2.zero;
        line.SetPosition(0, Vector2.zero);
        line.SetPosition(1, Vector2.zero);
    }
}

