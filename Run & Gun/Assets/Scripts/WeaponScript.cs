using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Vector2 bulletDirection;

    // Update is called once per frame
    void Update()
    {
        // shoots bullet
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}