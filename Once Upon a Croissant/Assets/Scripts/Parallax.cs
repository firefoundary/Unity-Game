using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPosX, startPosY;
    public GameObject cam;
    public float parallaxEffect;

    public bool yAxis;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        if (yAxis)
            startPosY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distX = (cam.transform.position.x * parallaxEffect);

        if (yAxis) {
            float distY = (cam.transform.position.y * parallaxEffect);
            transform.position = new Vector3(startPosX + distX, startPosY + distY, transform.position.z);
        } else
            transform.position = new Vector3(startPosX + distX, transform.position.y, transform.position.z);
    }
}
