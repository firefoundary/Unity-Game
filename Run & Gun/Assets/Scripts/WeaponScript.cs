using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Vector2 bulletDirection;
    public float bulletSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        bulletDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // shoots bullet
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // bullet shoots in lookDirection
        GameObject firedbullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        firedbullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;
    }
}