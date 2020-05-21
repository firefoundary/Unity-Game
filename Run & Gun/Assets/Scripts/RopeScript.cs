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
        // hook moves to where the mouse pos when right mb was clicked
        transform.position = Vector2.MoveTowards(transform.position, destiny, speed);

        if ((Vector2) transform.position != destiny)
        {
			if (Vector2.Distance (gun.transform.position, lastNode.transform.position) > distance) {
				
				CreateNode ();
			
			}
	
            
        } else if (done == false) {
				done = true;
				while(Vector2.Distance (gun.transform.position, lastNode.transform.position) > distance) {	
					CreateNode ();
				}
                lastNode.GetComponent<HingeJoint2D>().connectedBody = gun.GetComponent<Rigidbody2D>();
            }

		RenderLine();
    }

	void RenderLine() {
		lr.positionCount = vertexCount;
		
		int i;
		for (i = 0; i < Nodes.Count; i++) {

			lr.SetPosition (i, Nodes [i].transform.position);

		}

		lr.SetPosition (i, gun.transform.position);
	}


    void CreateNode()
    {
        Vector2 posCreate = gun.transform.position - lastNode.transform.position;
        posCreate.Normalize();
		posCreate *= distance;
		posCreate += (Vector2)lastNode.transform.position;
		GameObject go = (GameObject) Instantiate(node, posCreate, Quaternion.identity);
        
		go.transform.SetParent(transform);

        lastNode.GetComponent<HingeJoint2D>().connectedBody = go.gameObject.GetComponent<Rigidbody2D>();
 		lastNode = go;
		Nodes.Add(lastNode);
		vertexCount++;
    }
}
