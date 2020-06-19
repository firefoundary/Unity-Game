using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    //following Player
    public Transform player;
    public bool isFlipped = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LookAtPlayer() {

        //flips z axis as well
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped) 
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped) 
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }

    }



    // void Die()
    // {
    //     Vector3 position = new Vector3(transform.position.x, transform.position.y - 1, -8.8f);

    //     // death particles
    //     Instantiate(effect, position, Quaternion.identity);
    //     Instantiate(bloodSplash, position, Quaternion.identity);
    //     Destroy(gameObject);
    // }


}
