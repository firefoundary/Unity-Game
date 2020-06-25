using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject shotEffect;

    private float timeBtwShots;
    public float startTimeBtwShots;

    //audio
    public AudioSource shootSound;

    private PlayerMovement player;

    void Start() {
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeBtwShots <= 0 && !player.dialogueFreeze) {
            if (Input.GetMouseButtonDown(0)) {

                shootSound.Play();
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                timeBtwShots = startTimeBtwShots;

            }
         }
         else {
             timeBtwShots -= Time.deltaTime;
         }
     }
}