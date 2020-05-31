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
    private Vector2 grappleDir;

    private Vector3 velocity;

    private bool grappling = false;
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

        if (Input.GetKeyDown(KeyCode.Mouse0))
            setStart(grappleDir);

        if (!keepShooting)
            return; 
        
        if (grappling)
        {
            Vector2 dir = (Vector2) transform.position - origin.position;
            origin.AddForce(dir * pull_force);

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                breakGrapple();
                grappling = false;
                return;
            }
        }
        else
        {
            transform.position += velocity * Time.deltaTime;
            float distance = Vector2.Distance(transform.position, origin.position);
            if (distance > 10)
            {
                breakGrapple();
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
        line.SetPosition(0, Vector2.zero);
        line.SetPosition(1, Vector2.zero);
    }
}

