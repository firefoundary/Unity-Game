using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformSound : MonoBehaviour
{
    public AudioSource flap;

    public void flapSound() {
        flap.Play();
    }
}
