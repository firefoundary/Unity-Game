using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicTransition : MonoBehaviour
{
    private static MusicTransition instance;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("LevelFour")) {
            Debug.Log("hha");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
