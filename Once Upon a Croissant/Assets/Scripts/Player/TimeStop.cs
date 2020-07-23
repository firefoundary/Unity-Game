using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    public float changeTime, freezeTime;
    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    public void StopTime() {

        StopCoroutine(StartTimeAgain());
        StartCoroutine(StartTimeAgain());

        anim.SetBool("Damaged", true);

        Time.timeScale = changeTime;
    }

    IEnumerator StartTimeAgain() {
        yield return new WaitForSecondsRealtime(freezeTime);
        anim.SetBool("Damaged", false);
        Time.timeScale = 1f;

    }
}
