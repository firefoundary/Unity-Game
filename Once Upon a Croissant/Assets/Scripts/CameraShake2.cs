using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraShake2 : MonoBehaviour
{
    public float waitSeconds = 0.05f;
    public float amount = 0.02f;
    
    public new CinemachineVirtualCamera camera;
    public GameObject player;

    void Update() {

    }

    public IEnumerator Shake () {

        //make smooth?
        camera.m_Lens.OrthographicSize -= amount;
        yield return new WaitForSeconds(waitSeconds);
        camera.m_Lens.OrthographicSize += amount;
        yield return new WaitForSeconds(waitSeconds);
        camera.m_Lens.OrthographicSize -= amount;
        yield return new WaitForSeconds(waitSeconds);
        camera.m_Lens.OrthographicSize += amount;

    }

}
