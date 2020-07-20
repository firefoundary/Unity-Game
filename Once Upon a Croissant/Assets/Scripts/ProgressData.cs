using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class ProgressData
{
    public int progress;

    public ProgressData() {
        progress = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("created progress with sceneIndex: " + progress);
    }

}
