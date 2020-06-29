using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossShowDialogue : MonoBehaviour
{
    public FirstDialogue firstDialogue;
    public float delayTime;

    public GameObject bossObject;
    private BossHealth boss;

    // Start is called before the first frame update
    void Start()
    {
        boss = bossObject.GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.health <= 0) 
            StartCoroutine(WaitForSec());
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(delayTime);
        firstDialogue.TriggerDialogue();
        Destroy(gameObject);
    }
}

