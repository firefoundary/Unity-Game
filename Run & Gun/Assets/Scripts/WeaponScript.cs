using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject shotEffect;
    private Vector2 bulletDirection;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // bullet muzzle effect
            // Instantiate(shotEffect, firePoint.position, shotEffect.transform.rotation);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}