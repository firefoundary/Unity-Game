using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Vector2 lookDirection;
    public float bulletSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        
        GameObject firedbullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        firedbullet.GetComponent<Rigidbody2D>().velocity = lookDirection * bulletSpeed;
    }
}