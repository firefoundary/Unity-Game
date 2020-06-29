using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    public float  startTimeBtwSpawn;
    private float timeBtwSpawn;

    public GameObject egg;

    private float randomX;
    private Vector2 spawnLocation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0) 
        {
            randomX = Random.Range(23f, 60f);
            spawnLocation = new Vector2(randomX, transform.position.y);
            Instantiate(egg, spawnLocation, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else 
            timeBtwSpawn -= Time.deltaTime;
    }


    
}
