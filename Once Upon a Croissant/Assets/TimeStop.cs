using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    public float changeTime;
    public float freezeTime;
    public GameObject hitEffect;
    public GameObject hitEffect2;




    void Start() {
    }

    public void StopTime() {

        StopCoroutine(StartTimeAgain());
        StartCoroutine(StartTimeAgain());


        Instantiate(hitEffect, transform.position, Quaternion.identity);

        Vector3 pos = new Vector3 (transform.position.x, transform.position.y, hitEffect2.transform.position.z);
        Instantiate(hitEffect2, pos, Quaternion.identity);


        Time.timeScale = changeTime;
    }

    IEnumerator StartTimeAgain() {
        yield return new WaitForSecondsRealtime(freezeTime);
        Time.timeScale = 1f;

    }
}
