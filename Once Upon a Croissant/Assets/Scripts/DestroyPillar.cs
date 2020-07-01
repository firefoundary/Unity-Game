using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPillar : MonoBehaviour
{
    public GameObject pillar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            Destroy(pillar);
            Destroy(gameObject);
        }
    }
}
