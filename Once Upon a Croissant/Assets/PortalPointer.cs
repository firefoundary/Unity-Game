using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPointer : MonoBehaviour
{
    private Transform portal;
    private bool onScreen;

    private GameObject arrow;

    void Start() {
        portal = GameObject.Find("LevelLoader").transform;
        arrow = transform.Find("Arrow").gameObject;
    }

    void Update() {
        var dir = portal.position - transform.position;

        //rotates arrow to point at portal
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 180;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //checks if portal is on screen
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(portal.position);
        onScreen = screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        //enables or disables arrow
        if (onScreen)
            arrow.SetActive(false);
        else   
            arrow.SetActive(true);

    }
    
  

}
