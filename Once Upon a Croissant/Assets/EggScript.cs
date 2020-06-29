using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    public float speed;
    public float damage;
    public float degreesPerSec = 360f;



    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 1, transform.position.z) * speed;

        //spins egg 
        float rotateAmount = degreesPerSec * Time.deltaTime; 
        float curRotate = transform.localRotation.eulerAngles.z; 
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRotate + rotateAmount));
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground") || col.CompareTag("PlayerBullet")) {
            Destroy(gameObject);
            return;
        }

        Player player = col.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
