using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour {

    // referenses to controlled game objects
    public GameObject player, otherPrefab;


	private Cinemachine.CinemachineVirtualCamera virtualCam;	


    // Use this for initialization
    void Start () {
        virtualCam = GameObject.FindWithTag("VirtCam").GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }

    public void changeSprite() 
	{
		var temp = player.transform.position;
		otherPrefab.SetActive(true);
		transform.position = otherPrefab.transform.position;
 		otherPrefab.transform.position = temp;
		player.SetActive(false);	

        changeCameraFocus();
	}

    public void changeCameraFocus()
	{
		virtualCam.m_LookAt = otherPrefab.transform;
		virtualCam.m_Follow = otherPrefab.transform;
	}
}