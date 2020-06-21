using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cloak : MonoBehaviour {

    [SerializeField]
  	public TextMeshProUGUI pickUpText;
    public GameObject player;
	public GameObject otherPrefab;
    public ParticleSystem particles;
    public FirstDialogue Dialogue;
    private bool pickUpAllowed;
	private GameObject grapple;

	private Cinemachine.CinemachineVirtualCamera virtualCam;	

    // Use this for initialization
    private void Start ()
    {
        particles.Stop();
		virtualCam = GameObject.FindWithTag("VirtCam").GetComponent<Cinemachine.CinemachineVirtualCamera>();
		grapple = GameObject.FindWithTag("Grapple");
        pickUpText.gameObject.SetActive(false);
    }
	
    // Update is called once per frame
    private void Update () {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E)) 
		{
			changeSprite();
			changeCameraFocus();
            Instantiate(particles, player.transform.position, particles.transform.rotation);
            Dialogue.TriggerDialogue();
            PickUp();
		}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
    }

	void changeSprite() 
	{
		var temp = player.transform.position;
		otherPrefab.SetActive(true);
		transform.position = otherPrefab.transform.position;
 		otherPrefab.transform.position = temp;
		player.SetActive(false);	
	}

	void changeCameraFocus()
	{
		virtualCam.m_LookAt = otherPrefab.transform;
		virtualCam.m_Follow = otherPrefab.transform;
	}
}