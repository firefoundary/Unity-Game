using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickCounter : MonoBehaviour
{
    public int counter;

    public GameObject glowOrb;

    // Update is called once per frame
    void Update()
    {
        if (counter == 3) {
            glowOrb.SetActive(true);
        }
    }

    public void count() {
        counter += 1;
    }
}
