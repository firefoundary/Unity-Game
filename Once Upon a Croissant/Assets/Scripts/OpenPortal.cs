using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPortal : MonoBehaviour
{
    public GameObject portal;
    public int deathCounter;

    private GameObject[] enemies;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        deathCounter = enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (deathCounter == 0) {
            portal.SetActive(true);

            //enables portal pointer
            GameObject.FindWithTag("Player").transform.Find("Portal Pointer").gameObject.SetActive(true);
        }
    }
}
