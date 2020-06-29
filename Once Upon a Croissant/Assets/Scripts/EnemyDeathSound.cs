using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathSound : MonoBehaviour
{
    public AudioClip deathSound;
    private AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = deathSound;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
