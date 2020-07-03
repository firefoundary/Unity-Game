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
        GameObject.Find("Boss Baker").GetComponent<Animator>().SetTrigger("Killed");
        bossChoiceUI.SetActive(false);
    }

    public void Spare() { 
        GameObject.Find("Boss Baker").GetComponent<Animator>().SetTrigger("Spared");
        bossChoiceUI.SetActive(false);
    }
}
