using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPortal : MonoBehaviour
{
    public GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (!enemy)
            portal.SetActive(true);
    }
}
