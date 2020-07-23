using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playIfMusicNotExist : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject previousMusic = GameObject.Find("BG Music");
        if (!previousMusic) {
            GetComponent<AudioSource>().Play();
            GetComponent<MusicTransition>().enabled = true;
        }
    }
}
