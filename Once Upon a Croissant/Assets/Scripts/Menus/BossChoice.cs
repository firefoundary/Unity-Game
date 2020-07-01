using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChoice : MonoBehaviour
{
    public GameObject bossChoiceUI;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kill() {
        Debug.Log("killed");
        GameObject.Find("Boss Baker").GetComponent<Animator>().SetTrigger("Killed");
        bossChoiceUI.SetActive(false);
    }

    public void Spare() {
        Debug.Log("spared");
        GameObject.Find("Boss Baker").GetComponent<Animator>().SetTrigger("Spared");
        bossChoiceUI.SetActive(false);
    }
}
