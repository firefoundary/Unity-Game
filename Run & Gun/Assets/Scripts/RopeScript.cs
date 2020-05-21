using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{

    public Vector2 destiny;
    public float speed;
    public GameObject node;
    public GameObject gun;
    public GameObject go;
    private bool done = false;
    

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Gun");
    }

    // Update is called once per frame
    void Update() 
    { 
        // hook moves to where the mouse pos when right mb was clicked
        transform.position = Vector2.MoveTowards(transform.position, destiny, speed);

        if ((Vector2) transform.position == destiny)
        {
            if (done == false)
            {
                CreateNode();
                done = true;
                go.GetComponent<HingeJoint2D>().connectedBody = gun.GetComponent<Rigidbody2D>();
            }
        }
    }

    void CreateNode()
    {
        Vector2 posCreate = new Vector2(gun.transform.position.x + (float) 0.3, gun.transform.position.y);
        go = (GameObject) Instantiate(node, posCreate, Quaternion.identity);
        
        transform.gameObject.GetComponent<HingeJoint2D>().connectedBody = go.gameObject.GetComponent<Rigidbody2D>();
 
    }
}
