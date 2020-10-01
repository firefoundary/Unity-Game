using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraShakeBrackeys : MonoBehaviour
{

    public CinemachineVirtualCamera camera;


    public IEnumerator Shake (float duration, float magnitude) 
    {
        camera.m_Follow = null;

        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration) 
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
        camera.m_Follow = GameObject.Find("Cloak Croissant").transform;

    }
}
