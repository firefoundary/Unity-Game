using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwitchMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("BG Music"));
        Destroy(GameObject.Find("BGM"));
    }
}
