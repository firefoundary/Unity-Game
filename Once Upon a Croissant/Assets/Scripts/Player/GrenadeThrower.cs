using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 10;
    public GameObject grenadePrefab;
    public GameObject nadeIndicator;

    private float timeBtwShots;
    public float startTimeBtwShots;
    


    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0) {
            if (Input.GetKeyDown(KeyCode.Q)) {
                Instantiate(grenadePrefab, transform.position, transform.rotation);
                timeBtwShots = startTimeBtwShots; 
                StartCoroutine("coolDown");
            }
        }
        else
            timeBtwShots -= Time.deltaTime;
        
    }

    IEnumerator coolDown() {
        nadeIndicator.GetComponent<Image>().color = new Color (1, 1, 1, 0.2f);
        yield return new WaitForSeconds(startTimeBtwShots);
        nadeIndicator.GetComponent<Image>().color = new Color (1, 1, 1, 0.8f);

    }

    

}
