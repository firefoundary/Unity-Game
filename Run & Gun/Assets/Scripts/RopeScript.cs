using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
	public Vector2 destiny;
    public float speed;
	public float distance = 1;
    public GameObject node;
	public GameObject lastNode;
    public GameObject gun;
    private bool done = false;
    public LineRenderer lr;

	int vertexCount = 2;
	public List<GameObject> Nodes = new List<GameObject>();

    // Start is called before the first frame update
    void Start() {

		lr = GetComponent<LineRenderer>();
        gun = GameObject.FindGameObjectWithTag("Gun");
		lastNode = transform.gameObject;
		Nodes.Add(transform.gameObject);
    }

    // Update is called once per frame
    void Update() 
    { 
        // hook travels from gun to mouse position
        transform.position = Vector2.MoveTowards(transform.position, destiny, speed);

        if ((Vector2) transform.position != destiny)
        {
			if (Vector2.Distance (gun.transform.position, lastNode.transform.position) > distance) {
				
				CreateNode (); // makes a series of nodes between gun and hook
			
			}


        } else if (done == false) {
				done = true;
				while(Vector2.Distance (gun.transform.position, lastNode.transform.position) > distance) {	
					
					CreateNode (); // makes a series of nodes between gun and hook
					
				}
                lastNode.GetComponent<HingeJoint2D>().connectedBody = gun.GetComponent<Rigidbody2D>();
            }

		RenderLine();
    }

	void RenderLine() {
		lr.positionCount = vertexCount;
		int i;
		
		for (i = 0; i < Nodes.Count; i++) { //renders a line between every node

			lr.SetPosition (i, Nodes [i].transform.position);

		}

		lr.SetPosition (i, gun.transform.position);
	}


    void CreateNode()
    {
	    // creates nodes at an offset from the last node created
        Vector2 posCreate = gun.transform.position - lastNode.transform.position;
        posCreate.Normalize();
		posCreate *= distance;
		posCreate += (Vector2)lastNode.transform.position;
		GameObject go = (GameObject) Instantiate(node, posCreate, Quaternion.identity);
        
		go.transform.SetParent(transform);

		// adds created node to existing list of nodes 
        lastNode.GetComponent<HingeJoint2D>().connectedBody = go.gameObject.GetComponent<Rigidbody2D>();
 		lastNode = go;
		Nodes.Add(lastNode);
		vertexCount++;
    }
}
