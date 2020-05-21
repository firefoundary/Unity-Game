using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootHook : MonoBehaviour
{
    public GameObject hook;
    private GameObject curHook;
	public bool ropeActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
			if (ropeActive == false) {

            	Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            	curHook = (GameObject) Instantiate(hook, transform.position, Quaternion.identity);
            	curHook.GetComponent<RopeScript>().destiny = destiny;

				ropeActive = true;
            }  
        }

		if (Input.GetButtonDown("Jump")) { 
			// delete rope
			Destroy (curHook);
			ropeActive = false;	
		}
    }

}
