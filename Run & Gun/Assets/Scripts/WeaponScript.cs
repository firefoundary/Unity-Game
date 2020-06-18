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

    // Update is called once per frame
    void Update()
    {
        
        if (timeBtwShots <= 0) {
            if (Input.GetMouseButtonDown(0)) {
                // bullet muzzle effect
                // Instantiate(shotEffect, firePoint.position, shotEffect.transform.rotation);
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                timeBtwShots = startTimeBtwShots;
            }
         }
         else {
             timeBtwShots -= Time.deltaTime;
         }
     }
}