using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSounds : MonoBehaviour
{
    public AudioSource intro;
    public AudioSource charge;
    public AudioSource shoot;
    public AudioSource attack;
    public AudioSource defeated;
    public AudioSource killed;


    public AudioSource anger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void introSound() {
        intro.Play();
    }

    public void chargeSound() {
        charge.Play();
    }

    public void shootSound() {
        shoot.Play();
    }

    public void attackSound() {
        attack.Play();
    }

    public void defeatedSound() {
        defeated.Play();
    }

    public void angerSound() {
        anger.Play();
    }

    public void killedSound() {
        killed.Play();
    }
}
